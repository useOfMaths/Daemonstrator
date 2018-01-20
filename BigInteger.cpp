#include "stdafx.h"
#include "BigInteger.h"

const string error_phrase_illegal_number = " could not be converted to BigInteger.";
const string error_phrase_illegal_base = " is not supported as a number base. Supported bases range from 2 - 16.";
const int operation_base = 10;
static BigInteger ZERO(0);
static BigInteger ONE(1);
static BigInteger TEN(operation_base);

vector<BigInteger> grand_result;
vector<BigInteger> final_remainder;

struct operand {
	int sign; // 1 for -ve; 0 for +ve
	vector<int> value;
	vector<int> reverse_value;
	long long int long_value;
};

void BigInteger::inStringConstructor(const char * op)
{
	char magnet;
	int i = 0;
	base_operand.sign = 0;
	base_operand.value = {};
	base_operand.reverse_value = {};

	int number_length = 0;
	while (op[number_length] != '\0') { number_length++; }
	number_length--;

	if (op[0] == '-') {
		base_operand.sign = 1;
		i = 1;
	}
	// remove any appended zeroes
	while (i < number_length && op[i] == 0) {
		i++;
	}

	while (i <= number_length) {
		magnet = op[i++];
		if (isdigit(magnet)) {
			base_operand.value.push_back(atoi(&magnet));
			base_operand.reverse_value.insert(base_operand.reverse_value.begin(), atoi(&magnet));
		}
		else {
			throw (op + error_phrase_illegal_number);
			return;
		}
	}
}

void BigInteger::baseSpecific(const char * op, unsigned number_base)
{
	// reject if base > 16 or < 2;
	if (number_base > 16 || number_base < 2) {
		throw (op + error_phrase_illegal_base);
		return;
	}

	char number_bases[] = "0123456789abcdef";
	string reg_range = "";
	reg_range += number_bases[number_base - 1];
	reg_range += "])";
	if (number_base >= 10) {
		reg_range = "([0-9a-" + reg_range;
	}
	else {
		reg_range = "([0-" + reg_range;
	}
	regex verify_num(reg_range);

	char w;
	string char_string;

	int number_length = 0;
	while (op[number_length] != '\0') { number_length++; }
	number_length--;

	// remove any appended zeroes;
	int i = 0;
	while (i < number_length && op[i] == 0) {
		i++;
	}

	// convert number from base <number_base> to base 10
	BigInteger in_base_10(0);
	int j;
	while (i <= number_length) {
		char_string = "";
		w = op[i];
		tolower(w);
		char_string += w;
		if (regex_match(char_string, verify_num)) {
			j = 0;
			while (number_bases[j] != w) { j++; } // get char index
			in_base_10 = BigInteger::valueOf(j).multiply(BigInteger::valueOf(number_base).pow(number_length - i)).add(in_base_10);
			i++;
		}
		else {
			throw (op + error_phrase_illegal_number);
			return;
		}
	}
	*this = in_base_10;
}


/*
* Constructor for empty arguments
*/
BigInteger::BigInteger()
{
}


/*
* Constructor for unsigned int arguments
*/
BigInteger::BigInteger(unsigned op)
{
	base_operand.long_value = op;
	inStringConstructor((to_string(op)).c_str());
}
BigInteger::BigInteger(unsigned op, unsigned number_base)
{
	baseSpecific((to_string(op)).c_str(), number_base);
}


/*
* Constructor for int arguments
*/
BigInteger::BigInteger(int op)
{
	base_operand.long_value = op;
	inStringConstructor((to_string(op)).c_str());
}

BigInteger::BigInteger(int op, unsigned number_base)
{
	baseSpecific((to_string(op)).c_str(), number_base);
}


/*
* Constructor for long int arguments
*/
BigInteger::BigInteger(long int op)
{
	base_operand.long_value = op;
	inStringConstructor((to_string(op)).c_str());
}

BigInteger::BigInteger(long int op, unsigned number_base)
{
	baseSpecific((to_string(op)).c_str(), number_base);
}


/*
* Constructor for long long int arguments
*/
BigInteger::BigInteger(long long int op)
{
	base_operand.long_value = op;
	inStringConstructor((to_string(op)).c_str());
}

BigInteger::BigInteger(long long int op, unsigned number_base)
{
	baseSpecific((to_string(op)).c_str(), number_base);
}


/*
 * Constructor for string arguments
*/
BigInteger::BigInteger(string op)
{
	// if op_1 < size of long long int
	if (op.length() < INT_MAX_LENGTH) {
		string c = op;
		base_operand.long_value = atoll(op.c_str());
	}
	inStringConstructor(op.c_str());
}

BigInteger::BigInteger(string op, unsigned number_base)
{
	baseSpecific(op.c_str(), number_base);
}


/*
* Constructor for sign and values
*/
BigInteger::BigInteger(int sn, vector<int> vl)
{
	// remove any prepended zeroes;
	while (vl.size() > 1 && vl.front() == 0) {
		vl.erase(vl.begin());
	}
	base_operand.sign = sn;
	string li = "";
	if (sn == 1) { li = "-"; }
	base_operand.value = {};
	base_operand.reverse_value = {};
	for (int e : vl) {
		base_operand.value.push_back(e);
		base_operand.reverse_value.insert(base_operand.reverse_value.begin(), e);
		li += to_string(e);
	}
	// if op_1 < size of long long int
	if (li.length() < INT_MAX_LENGTH) {
		base_operand.long_value = atoll(li.c_str());
	}
}


/*
* Overload Equals operator
*/
BigInteger& BigInteger::operator= (const BigInteger& attached_operand)
{
	base_operand.sign = attached_operand.base_operand.sign;
	base_operand.long_value = attached_operand.base_operand.long_value;
	base_operand.value = {};
	base_operand.reverse_value = {};
	for (int e : attached_operand.base_operand.value) {
		base_operand.value.push_back(e);
		base_operand.reverse_value.insert(base_operand.reverse_value.begin(), e);
	}
	return *this;
}


/*
* return string value of base operand
*/
string BigInteger::toString() {
	string ret = "";
	// if number was -ve
	if (base_operand.sign == 1) {
		ret += "-";
	}
	for (int z = 0; z < base_operand.value.size(); z++) {
		ret += to_string(base_operand.value[z]);
	}
	return ret;
}

string BigInteger::toString(unsigned number_base) {
	// reject if base > 16 or < 2;
	if (number_base > 16 || number_base < 2) {
		throw (to_string(number_base) + error_phrase_illegal_base);
		return "";
	}

	string ret = "";
	// if number was -ve
	if (base_operand.sign == 1) {
		ret += "-";
	}

	vector<BigInteger> in_base = { *this, ZERO };
	vector<int> zero = { 0 };
	char number_bases[] = "0123456789abcdef";
	string digits = "";
	// convert number from base 10 to base <number_base>
	int i;
	do {
		in_base = in_base[0].divideAndRemainder(BigInteger::valueOf(number_base));
		i = std::abs(in_base[1].intValue());
		digits = number_bases[i] + digits;
	} while (!eq(&(in_base[0].base_operand.value), &zero));

	ret += digits;
	return ret;
}


/*
* return int value of base operand
*/
int BigInteger::intValue() {
	string ret = "";
	if (base_operand.sign == 1) {
		ret += "-";
	}
	for (int z = 0; z < base_operand.value.size(); z++) {
		ret += to_string(base_operand.value[z]);
	}
	return stoi(ret);
}


BigInteger BigInteger::valueOf(string s) {
	return BigInteger(s);
}
BigInteger BigInteger::valueOf(unsigned u) {
	return BigInteger(u);
}
BigInteger BigInteger::valueOf(int i) {
	return BigInteger(i);
}
BigInteger BigInteger::valueOf(long int i) {
	return BigInteger(i);
}
BigInteger BigInteger::valueOf(long long int i) {
	return BigInteger(i);
}
BigInteger BigInteger::valueOf(int s, vector<int> v) {
	return BigInteger(s, v);
}


/*
* Greater than
*/
bool BigInteger::gt(vector<int>* base, vector<int>* attached)
{
	// see which vector has the bigger size
	if (base->size() > attached->size()) {
		return true;
	}
	else if (base->size() < attached->size()) {
		return false;
	}
	else { // vector sizes are equal; check  the digits
		int i = 0;
		while (i < base->size() && (*base)[i] == (*attached)[i]) {
			i++;
		}
		if (i == base->size()) { i--; }
		if ((*base)[i] > (*attached)[i]) {
			return true;
		}
		else {
			return false;
		}
	}
}

bool BigInteger::greaterThan(BigInteger& attached_operand)
{
	// if size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return (this->base_operand.long_value > attached_operand.base_operand.long_value);
	}

	// see which number has the bigger sign
	if (this->base_operand.sign > attached_operand.base_operand.sign) {
		return true;
	}
	else if (this->base_operand.sign < attached_operand.base_operand.sign) {
		return false;
	}
	else { // signs are equal
		return gt(&(this->base_operand.value), &(attached_operand.base_operand.value));
	}
}

/*
* Greater than or equal
*/
bool BigInteger::geq(vector<int>* base, vector<int>* attached)
{
	// see which vector has the bigger size
	if (base->size() > attached->size()) {
		return true;
	}
	else if (base->size() < attached->size()) {
		return false;
	}
	else { // vector sizes are equal; check  the digits
		int i = 0;
		while (i < base->size() && (*base)[i] == (*attached)[i]) {
			i++;
		}
		if (i == base->size()) { i--; }
		if ((*base)[i] >= (*attached)[i]) {
			return true;
		}
		else {
			return false;
		}
	}
}

bool BigInteger::greaterOrEquals(BigInteger& attached_operand)
{
	// if size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return (this->base_operand.long_value >= attached_operand.base_operand.long_value);
	}

	// see which number has the bigger sign
	if (this->base_operand.sign > attached_operand.base_operand.sign) {
		return true;
	}
	else if (this->base_operand.sign < attached_operand.base_operand.sign) {
		return false;
	}
	else { // signs are equal
		return geq(&(this->base_operand.value), &(attached_operand.base_operand.value));
	}
}

/*
* Less than
*/
bool BigInteger::lt(vector<int>* base, vector<int>* attached)
{
	// see which vector has the bigger size
	if (base->size() < attached->size()) {
		return true;
	}
	else if (base->size() > attached->size()) {
		return false;
	}
	else { // vector sizes are equal; check  the digits
		int i = 0;
		while (i < base->size() && (*base)[i] == (*attached)[i]) {
			i++;
		}
		if (i == base->size()) { i--; }
		if ((*base)[i] < (*attached)[i]) {
			return true;
		}
		else {
			return false;
		}
	}
}

bool BigInteger::lesserThan(BigInteger& attached_operand)
{
	// if size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return (this->base_operand.long_value < attached_operand.base_operand.long_value);
	}

	// see which number has the bigger sign
	if (this->base_operand.sign < attached_operand.base_operand.sign) {
		return true;
	}
	else if (this->base_operand.sign > attached_operand.base_operand.sign) {
		return false;
	}
	else { // signs are equal
		return lt(&(this->base_operand.value), &(attached_operand.base_operand.value));
	}
}

/*
* Less than
*/
bool BigInteger::leq(vector<int>* base, vector<int>* attached)
{
	// see which vector has the bigger size
	if (base->size() < attached->size()) {
		return true;
	}
	else if (base->size() > attached->size()) {
		return false;
	}
	else { // vector sizes are equal; check  the digits
		int i = 0;
		while (i < base->size() && (*base)[i] == (*attached)[i]) {
			i++;
		}
		if (i == base->size()) { i--; }
		if ((*base)[i] <= (*attached)[i]) {
			return true;
		}
		else {
			return false;
		}
	}
}

bool BigInteger::lesserOrEquals(BigInteger& attached_operand)
{
	// if size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return (this->base_operand.long_value <= attached_operand.base_operand.long_value);
	}

	// see which number has the bigger sign
	if (this->base_operand.sign < attached_operand.base_operand.sign) {
		return true;
	}
	else if (this->base_operand.sign > attached_operand.base_operand.sign) {
		return false;
	}
	else { // signs are equal
		return leq(&(this->base_operand.value), &(attached_operand.base_operand.value));
	}
}

/*
* Equals
*/
bool BigInteger::eq(vector<int>* base, vector<int>* attached)
{
	// vector sizes are equal; check  the digits (vectors are big endian)
	if (base->size() == attached->size()) {
		int i = 0;
		while (i < base->size() && (*base)[i] == (*attached)[i]) {
			i++;
		}
		if (i == base->size()) {
			return true;
		}
	}
	return false;
}

bool BigInteger::equals(BigInteger& attached_operand)
{
	// if size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return (this->base_operand.long_value == attached_operand.base_operand.long_value);
	}

	// see if sign signs are the same
	if (this->base_operand.sign == attached_operand.base_operand.sign) {
		return eq(&(this->base_operand.value), &(attached_operand.base_operand.value));
	}
	else {
		return false;
	}
}

// not equals
bool BigInteger::notEquals(BigInteger& attached_operand)
{
	// if size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return (this->base_operand.long_value != attached_operand.base_operand.long_value);
	}

	// see if sign signs are the same
	if (this->base_operand.sign == attached_operand.base_operand.sign) {
		return !eq(&(this->base_operand.value), &(attached_operand.base_operand.value));
	}
	else {
		return true;
	}
}


/*
* Do addition check
*/
BigInteger BigInteger::abs()
{
	return BigInteger(0, base_operand.value);
}

/*
* Do addition
*/
vector<int> BigInteger::addValues(vector<int> * op_1, vector<int> * op_2)
{
	vector<int> result;

	vector<int> * operand_1 = op_1;
	vector<int> * operand_2 = op_2;

	int carry_over = 0;
	int rs = 0;
	// use number with more digits for iteration
	for (int j = 0; j < operand_1->size(); j++) {
		if (j < operand_2->size()) {
			rs = (*operand_1)[j] + (*operand_2)[j] + carry_over;
		}
		else {
			rs = (*operand_1)[j] + carry_over;
		}
		result.push_back(rs % operation_base);
		carry_over = (int)floor(rs / operation_base);
	}
	result.push_back(carry_over);

	return result;
}


/*
 * Do addition check
*/
BigInteger BigInteger::add(BigInteger& attached_operand)
{
	// if size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return BigInteger(this->base_operand.long_value + attached_operand.base_operand.long_value);
	}

	int sign = 0;
	// see which vector has the bigger size
	vector<int> * op_1;
	vector<int> * op_2;
	if (geq(&(this->base_operand.value), &(attached_operand.base_operand.value))) {
		op_1 = &(this->base_operand.reverse_value);
		op_2 = &(attached_operand.base_operand.reverse_value);
		sign = this->base_operand.sign;
	}
	else {
		op_1 = &(attached_operand.base_operand.reverse_value);
		op_2 = &(this->base_operand.reverse_value);
		sign = attached_operand.base_operand.sign;
	}

	// just do subtraction if only one operand is signed
	if (this->base_operand.sign ^ attached_operand.base_operand.sign) {
		vector<int> sum = subtractValues(op_1, op_2);
		reverse(sum.begin(), sum.end());

		return BigInteger(sign, sum);
	}
	// result will be signed if both operands are signed
	else if (this->base_operand.sign & attached_operand.base_operand.sign) {
		sign = 1; // set sign to -ve
	}
	else { sign = 0; }

	vector<int> sum = addValues(op_1, op_2);
	reverse(sum.begin(), sum.end());

	return BigInteger(sign, sum);
}


/*
* Do subtraction
*/
vector<int> BigInteger::subtractValues(vector<int> * op_1, vector<int> * op_2)
{
	vector<int> result;

	vector<int> * operand_1 = op_1;
	vector<int> * operand_2 = op_2;

	int borrow_over = 0;
	int rs = 0;
	// use number with more digits for iteration
	for (int j = 0; j < operand_1->size(); j++) {
		if (j < operand_2->size()) {
			if ((*operand_1)[j] >= (*operand_2)[j] + borrow_over) {
				rs = (*operand_1)[j] - (*operand_2)[j] - borrow_over;
				borrow_over = 0;
			}
			else {
				rs = (*operand_1)[j] + operation_base - (*operand_2)[j] - borrow_over;
				borrow_over = 1;
			}
		}
		else {
			if ((*operand_1)[j] >= borrow_over) {
				rs = (*operand_1)[j] - borrow_over;
				borrow_over = 0;
			}
			else {
				rs = (*operand_1)[j] + operation_base - borrow_over;
				borrow_over = 1;
			}
		}
		result.push_back(rs);
	}

	return result;
}


/*
* Do subtraction check
*/
BigInteger BigInteger::subtract(BigInteger& attached_operand)
{
	// if size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return BigInteger(this->base_operand.long_value - attached_operand.base_operand.long_value);
	}

	// just do addition if only one operand is signed
	int sign = 0;
	// see which vector has the bigger size
	vector<int> * op_1;
	vector<int> * op_2;
	if (geq(&(this->base_operand.value), &(attached_operand.base_operand.value))) {
		op_1 = &(this->base_operand.reverse_value);
		op_2 = &(attached_operand.base_operand.reverse_value);
		sign = this->base_operand.sign;
	}
	else {
		op_1 = &(attached_operand.base_operand.reverse_value);
		op_2 = &(this->base_operand.reverse_value);
		sign = attached_operand.base_operand.sign;
	}

	if (this->base_operand.sign ^ attached_operand.base_operand.sign) {
		sign = 0;
		if (this->base_operand.sign == 1) {
			sign = 1; // set sign to -ve
		}
		vector<int> difference = addValues(op_1, op_2);
		reverse(difference.begin(), difference.end());

		return BigInteger(sign, difference);
	}

	vector<int> difference = subtractValues(op_1, op_2);
	reverse(difference.begin(), difference.end());

	return BigInteger(sign, difference);
}


/*
* Do multiplication
*/
vector<int> BigInteger::multiplyValues(vector<int> * base, vector<int> * attached)
{
	vector<int> result;

	size_t host_sz = base->size();
	size_t guest_sz = attached->size();
	// simulate a 2X2 run time array
	int** rs_mul = new int*[guest_sz];
	int * rs = new int[host_sz + guest_sz];
	// inititiate with zeros
	for (int z = 0; z < host_sz + guest_sz; z++) {
		rs[z] = 0;
	}
	// where i+j tallys, sum up to get final result
	for (int i = 0; i < guest_sz; i++) {
		rs_mul[i] = new int[host_sz];
		for (int j = 0; j < host_sz; j++) {
			rs_mul[i][j] = (*attached)[i] * (*base)[j];
			rs[i + j] += rs_mul[i][j];
		}
		delete[] rs_mul[i];
	}
	delete[] rs_mul;
	int carry_over = 0;
	// account for carry overs
	for (int k = 0; k < host_sz + guest_sz; k++) {
		result.push_back((rs[k] + carry_over) % operation_base);
		carry_over = (int)floor((rs[k] + carry_over) / operation_base);
	}
	delete[] rs;

	return result;
}


/*
* Do multiplication check
*/
BigInteger BigInteger::multiply(BigInteger& attached_operand)
{
	// if size of long long int
	if ((this->base_operand.value.size() + attached_operand.base_operand.value.size()) < INT_MAX_LENGTH) {
		return BigInteger(this->base_operand.long_value * attached_operand.base_operand.long_value);
	}

	// set result sign accordingly
	int sign = this->base_operand.sign ^ attached_operand.base_operand.sign;

	// return zero if any of the operands is zero
	vector<int> zero = { 0 };
	vector<int> one = { 1 };
	if (eq(&(this->base_operand.value), &zero) || eq(&(attached_operand.base_operand.value), &zero)) {
		return ZERO;
	}
	// return other operand if any of the operands is one
	else if (eq(&(this->base_operand.value), &one)) {
		return BigInteger(sign, attached_operand.base_operand.value);
	}
	else if (eq(&(attached_operand.base_operand.value), &one)) {
		return BigInteger(sign, this->base_operand.value);
	}

	vector<int> product = multiplyValues(&(this->base_operand.reverse_value), &(attached_operand.base_operand.reverse_value));
	reverse(product.begin(), product.end());

	return BigInteger(sign, product);
}


/*
* Do exponentiation
*/
BigInteger BigInteger::pow(unsigned int index)
{
	// just return 0 if index is < 1
	if (index == 1) {
		return *this;
	}
	else if (index == 0) {
		return ONE;
	}
	else if (index < 0) {
		return ZERO;
	}

	// if number is big integer enough
	BigInteger ret;
	ret = *this;
	vector<BigInteger> ret_array = { ret };

	int count = 1;
	int step = 1;
	bool retrace = false;
	while (count < index) {
		if (count + step <= index) {
			ret = ret.multiply(ret_array[ret_array.size() - 1]);
			count += step;
			if (!retrace) {
				step *= 2; // double up step
				ret_array.push_back(ret);
			}
		}
		else {
			step /= 2;
			retrace = true;
			ret_array.pop_back();
		}
	}

	return ret;
}


/*
* Do Long division
*/
void BigInteger::divideLongValues(BigInteger::operand * base, BigInteger::operand * attached)
{
	size_t host_sz = base->value.size();
	size_t guest_sz = attached->value.size();

	int * rs_mul = new int[host_sz];
	vector<int> residue = {};
	// copy up base operand
	for (size_t m = 0; m < host_sz; m++) {
		residue.push_back(base->value[m]);
	}

	// result for this call
	vector<int> partial_result = {};
	long long int rs = 0;
	// convert result to big integer
	BigInteger big_result(0);

	int carry_over = 0;
	// simulate a long division process
	int i, k = 0;
	for (i = 0; i <= host_sz - guest_sz; i++) {
		residue[i] += carry_over * operation_base;
		partial_result.push_back((int)floor(residue[i] / attached->value[0]));
		rs *= operation_base; // multiply by 10
		rs += partial_result[i]; // add up accumulating results
		k++;
		if (to_string(rs).length() >= INT_MAX_LENGTH) {
			big_result = big_result.multiply(TEN.pow(k)).add(valueOf(rs));
			rs = 0; k = 0; // rs has become too big; reset
		}
		for (int j = 0; j < guest_sz; j++) {
			rs_mul[j] = partial_result[i] * attached->value[j];
			residue[i + j] -= rs_mul[j];
		}
		carry_over = residue[i];
	}
	delete[] rs_mul;
	if (i < residue.size()) {
		residue[i] += carry_over * operation_base;
	}
	else {
		i--;
	}
	// save any results left
	big_result = big_result.multiply(TEN.pow(k)).add(valueOf(rs));

	// set result sign accordingly
	if (grand_result.size() > 0) {
		big_result.base_operand.sign = grand_result[grand_result.size() - 1].base_operand.sign ^ base->sign;
	}
	else {
		big_result.base_operand.sign = base->sign ^ attached->sign;
	}
	grand_result.push_back(big_result); //  save this result to grand stack

										// convert remainder to big integer
	BigInteger big_remainder(0);
	rs = 0; k = 0;
	for (; i < host_sz; i++) {
		rs *= operation_base; // multiply by 10
		rs += residue[i];
		k++;
		if (to_string(rs).length() >= INT_MAX_LENGTH) {
			big_remainder = big_remainder.multiply(TEN.pow(k)).add(valueOf(rs));
			rs = 0; k = 0;
		}
	}
	big_remainder = big_remainder.multiply(TEN.pow(k)).add(valueOf(rs));

	// if residue >= divisor; recurse.
	if (geq(&(big_remainder.base_operand.value), &(attached->value))) {
		return divideLongValues(&(big_remainder.base_operand), attached);
	}

	// save residue for modulo
	i = grand_result.size() - 1;
	vector<int> zero = { 0 };
	if (gt(&(big_remainder.base_operand.value), &zero)
		&& grand_result[i].base_operand.sign ^ big_remainder.base_operand.sign == 1) {
		grand_result[i] = grand_result[i].subtract(ONE);
		big_remainder = valueOf(0, attached->value).subtract(big_remainder.abs());
	}
	final_remainder.push_back(big_remainder); //  save this residue
}

/*
* Do division
*/
vector<int> BigInteger::divideValues(vector<int> * base, long long int denominator)
{
	denominator = std::abs(denominator);
	size_t host_sz = base->size();

	long long int numerator;
	// result for this call
	vector<int> result = {};

	int carry_over = 0;
	// carry out division process
	for (int i = 0; i < host_sz; i++) {
		numerator = carry_over * operation_base + (*base)[i];
		result.push_back((int)floor(numerator / denominator));
		carry_over = numerator % denominator;
	}
	result.push_back(carry_over); // save up modulo as last member

	return result;
}


/*
* Do division check
*/
BigInteger BigInteger::divide(BigInteger& attached_operand)
{
	int sign = this->base_operand.sign ^ attached_operand.base_operand.sign;
	
	// just return 0 if numerator < denominator
	if (lt(&(this->base_operand.value), &(attached_operand.base_operand.value))) {
		return ZERO;
	}
	// or 1 with the apt sign if they are equal
	else if (eq(&(this->base_operand.value), &(attached_operand.base_operand.value))) {
		vector<int> one = { 1 };
		return BigInteger(sign, one);
	}

	// if size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return BigInteger((long long int)floor(this->base_operand.long_value / attached_operand.base_operand.long_value));
	}
	
	// if only denominator is of long long int
	if (attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		vector<int> dividend = divideValues(&(this->base_operand.value), attached_operand.base_operand.long_value);
		dividend.pop_back();
		return BigInteger(sign, dividend);
	}

	grand_result = {};
	divideLongValues(&(this->base_operand), &(attached_operand.base_operand));
	BigInteger ret = grand_result[0];
	for (int m = 1; m < grand_result.size(); m++) {
		ret = ret.add(grand_result[m]);
	}

	return ret;
}


/*
* Do modulo
*/
BigInteger BigInteger::mod(BigInteger& attached_operand)
{
	// just return numerator if numerator < denominator
	if (lt(&(this->base_operand.value), &(attached_operand.base_operand.value))) {
		return *this;
	}
	// or 0 if they are equal
	else if (eq(&(this->base_operand.value), &(attached_operand.base_operand.value))) {
		return ZERO;
	}

	// if op_1 < size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return BigInteger((long long int)(this->base_operand.long_value % attached_operand.base_operand.long_value));
	}

	// if only denominator is of long long int
	if (attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		vector<int> dividend = divideValues(&(this->base_operand.value), attached_operand.base_operand.long_value);
		long long int remainder = dividend.back();
		if (this->base_operand.sign ^ attached_operand.base_operand.sign) {
			remainder = 0 - remainder;
		}
		return BigInteger(remainder);
	}

	// for the very long numbers
	final_remainder = {};
	divideLongValues(&(this->base_operand), &(attached_operand.base_operand));
	final_remainder[0].base_operand.sign = this->base_operand.sign ^ attached_operand.base_operand.sign;

	return final_remainder[0];
}
BigInteger BigInteger::remainder(BigInteger& attached_operand)
{
	return mod(attached_operand);
}


/*
* Do division and remainder
*/
vector<BigInteger> BigInteger::divideAndRemainder(BigInteger& attached_operand)
{
	int sign = this->base_operand.sign ^ attached_operand.base_operand.sign;

	// just return 0 if numerator < denominator
	if (lt(&(this->base_operand.value), &(attached_operand.base_operand.value))) {
		return{ ZERO, *this };
	}
	// or 1 with the apt sign
	else if (eq(&(this->base_operand.value), &(attached_operand.base_operand.value))) {
		vector<int> one = { 1 };
		return { BigInteger(sign, one), ZERO };
	}

	// if size of long long int
	if (this->base_operand.value.size() < INT_MAX_LENGTH && attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		return {
			BigInteger((long long int)floor(this->base_operand.long_value / attached_operand.base_operand.long_value)),
			BigInteger((long long int)(this->base_operand.long_value % attached_operand.base_operand.long_value))
		};
	}

	// if only denominator is of long long int
	if (attached_operand.base_operand.value.size() < INT_MAX_LENGTH) {
		vector<int> dividend = divideValues(&(this->base_operand.value), attached_operand.base_operand.long_value);
		long long int remainder = dividend.back();
		dividend.pop_back();
		if (sign) {
			remainder = 0 - remainder;
		}
		return { BigInteger(sign, dividend), BigInteger(remainder) };
	}

	// for the very long numbers
	grand_result = {};
	final_remainder = {};
	divideLongValues(&(this->base_operand), &(attached_operand.base_operand));

	BigInteger dividend(0);
	for (BigInteger B : grand_result) {
		dividend = dividend.add(B);
	}
	final_remainder[0].base_operand.sign = this->base_operand.sign ^ attached_operand.base_operand.sign;

	return { dividend, final_remainder[0] };
}


BigInteger::~BigInteger()
{
}
