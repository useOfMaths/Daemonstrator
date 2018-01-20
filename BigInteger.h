#pragma once

#include <string>
#include <sstream>
#include <vector>
#include <stdio.h>
#include <ctype.h>
#include <regex>

using namespace std;

#define INT_MAX_LENGTH 18

class BigInteger
{
public:
	BigInteger();
	BigInteger(unsigned);
	BigInteger(unsigned, unsigned);
	BigInteger(int);
	BigInteger(int, unsigned);
	BigInteger(long int);
	BigInteger(long int, unsigned);
	BigInteger(long long int);
	BigInteger(long long int, unsigned);
	BigInteger(string);
	BigInteger(string, unsigned);
	BigInteger& operator= (const BigInteger&);
	virtual ~BigInteger();

	int intValue(void);
	string toString(void);
	string toString(unsigned);
	static BigInteger valueOf(string);
	static BigInteger valueOf(unsigned);
	static BigInteger valueOf(int);
	static BigInteger valueOf(long int);
	static BigInteger valueOf(long long int);

	bool lesserThan(BigInteger&);
	bool lesserOrEquals(BigInteger&);
	bool greaterThan(BigInteger&);
	bool greaterOrEquals(BigInteger&);
	bool equals(BigInteger&);
	bool notEquals(BigInteger&);
	BigInteger abs(void);
	BigInteger add(BigInteger&);
	BigInteger subtract(BigInteger&);
	BigInteger multiply(BigInteger&);
	BigInteger pow(unsigned int);
	BigInteger divide(BigInteger&);
	BigInteger mod(BigInteger&);
	BigInteger remainder(BigInteger&);
	vector<BigInteger> divideAndRemainder(BigInteger&);

private:
	BigInteger(int, vector<int>);
	static BigInteger valueOf(int, vector<int>);
	struct operand {
		int sign;
		vector<int> value;
		vector<int> reverse_value;
		long long int long_value;
	};
	operand base_operand;

	void inStringConstructor(const char*);
	void baseSpecific(const char*, unsigned);

	vector<int> addValues(vector<int> *, vector<int> *);
	vector<int> subtractValues(vector<int> *, vector<int> *);
	vector<int> multiplyValues(vector<int> *, vector<int> *);
	vector<int> divideValues(vector<int> *, long long int);
	void divideLongValues(operand *, operand *);

	bool lt(vector<int>*, vector<int>*);
	bool leq(vector<int>*, vector<int>*);
	bool gt(vector<int>*, vector<int>*);
	bool geq(vector<int>*, vector<int>*);
	bool eq(vector<int>*, vector<int>*);
};

