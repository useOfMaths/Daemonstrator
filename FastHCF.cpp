#include "stdafx.h"
#include "FastHCF.h"


FastHCF::FastHCF(vector<unsigned> group) {
	common_factors = {};
	group.shrink_to_fit();
	sort(group.begin(), group.end());

	array_length = group.size();
	set_of_numbers = new int[array_length];
	arg_copy = new int[array_length];
	index = 0;

	//iterate through and retrieve members
	for (int number : group) {
		set_of_numbers[index] = number;
		arg_copy[index] = number;
		index++;
	}

	index = 2;
	all_round_factor = false;
}

int FastHCF::onlyPrimeFactors(unsigned in_question) {
	int temp_limit;
	temp_limit = (int)ceil(sqrt(in_question));

	while (index <= temp_limit) {
		if (index != 1 && (in_question % index) == 0) { // avoid an infinite loop with the i != 1 check.
			minimal_prime_factors.push_back(index);
			return onlyPrimeFactors(in_question / index);
		}
		index++;
	}
	minimal_prime_factors.push_back(in_question);

	return 0;
}

/**
* This function searches for mutual factors using an already computed
* list of factors(for the smallest member of 'set_of_numbers').
* @return - Nil
*/
int FastHCF::findHCFFactors() {
	while (index < minimal_prime_factors.size()) {

		all_round_factor = true;
		for (int j = 0; j < array_length; j++) {
			if (!(all_round_factor == true &&
				(arg_copy[j] % minimal_prime_factors[index]) == 0)) {
				all_round_factor = false;
			}
		}
		if (all_round_factor == true) {
			for (int j = 0; j < array_length; j++) {
				arg_copy[j] /= minimal_prime_factors[index];
			}
			common_factors.push_back(minimal_prime_factors[index]);
		}
		index++;
	}

	return 0;
}

/**
* Just calls out and collects the prepared factors.
*/
unsigned FastHCF::getHCF() {
	index = 2;
	onlyPrimeFactors(set_of_numbers[0]);
	minimal_prime_factors.shrink_to_fit();

	index = 0;
	findHCFFactors();
	common_factors.shrink_to_fit();

	//iterate through and retrieve members
	calc_result = 1;
	for (unsigned factor : common_factors) {
		calc_result *= factor;
	};

	return calc_result;
}


FastHCF::~FastHCF() {
	delete[] set_of_numbers;
	delete[] arg_copy;
}
