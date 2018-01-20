#include "stdafx.h"
#include "HCF.h"


HCF::HCF(vector<unsigned> group) {
	common_factors = {};
	group.shrink_to_fit();
	array_length = group.size();
	set_of_numbers = new int[array_length];
	index = 0;

	sort(group.begin(), group.end());

	//iterate through and retrieve members
	for (int number : group) {
		set_of_numbers[index] = number;
		index++;
	}

	index = 2;
	all_round_factor = false;
}

/**
* Our function checks 'set_of_numbers'; If it finds a factor common to
* all for it, it records this factor; then divides 'set_of_numbers' by the
* common factor found and makes this the new 'set_of_numbers'. It
* continues recursively until all common factors are found.
*/
int HCF::HCFFactors() {
	while (index <= set_of_numbers[0]) {

		// Check for factors common to every member of 'set_of_numbers'
		all_round_factor = true;
		for (int j = 0; j < array_length; j++) {
			if (!(all_round_factor == true && (set_of_numbers[j] % index) == 0)) {
				all_round_factor = false;
			}
		}
		// Divide every member of 'set_of_numbers' by each common factor
		if (all_round_factor == true) {
			for (int j = 0; j < array_length; j++) {
				set_of_numbers[j] /= index;
			}
			common_factors.push_back(index);
			return HCFFactors();
		}
		index++;
	}

	return 0;
}

/**
* Just calls out and collects the prepared factors.
* @param - None.
*/
unsigned HCF::getHCF() {
	HCFFactors();
	common_factors.shrink_to_fit();

	//iterate through and retrieve members
	calc_result = 1;
	for (unsigned factor : common_factors) {
		calc_result *= factor;
	};

	return calc_result;
}


HCF::~HCF() {
	delete[] set_of_numbers;
}
