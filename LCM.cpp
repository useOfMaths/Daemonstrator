#include "stdafx.h"
#include "LCM.h"

// descending sort function
bool isGreater(int i, int j) { return i > j; }


LCM::LCM(vector<unsigned> group) {
	all_factors = {};
	group.shrink_to_fit();
	sort(group.begin(), group.end());

	array_length = group.size();
	set_of_numbers = new unsigned[array_length];
	arg_copy = new unsigned[array_length];
	index = 0;

	//iterate through and retrieve members
	for (unsigned number : group) {
		set_of_numbers[index] = number;
		index++;
	}
	// Sort array in descending order
	sort(set_of_numbers, set_of_numbers + array_length, isGreater);

	index = 2;
	state_check = false;
}

/**
* Our function checks 'set_of_numbers'; If it finds a factor common to all
* for it, it records this factor; then divides 'set_of_numbers' by the
* common factor found and makes this the new 'set_of_numbers'. It continues
* recursively until all common factors are found.
*
*/
int LCM::LCMFactors() {
	//  Copy 'set_of_numbers' into 'arg_copy'
	for (unsigned count=0; count < array_length; count++ ) {
		arg_copy[count] = set_of_numbers[count];
	}
	// sort in descending order
	sort(arg_copy, arg_copy + array_length, isGreater);

	while (index <= arg_copy[0]) {
		state_check = false;
		for (unsigned j = 0; j < array_length; j++) {
			if ((set_of_numbers[j] % index) == 0) {
				set_of_numbers[j] /= index;
				if (state_check == false) {
					all_factors.push_back(index);
				}
				state_check = true;
			}
		}
		if (state_check == true) {
			return LCMFactors();
		}
		index++;
	}

	return 0;
}

/**
* Just calls out and collects the prepared factors.
*
* @param - None.
*/
unsigned LCM::getLCM() {
	index = 2;
	LCMFactors();
	all_factors.shrink_to_fit();

	//iterate through and retrieve members
	calc_result = 1;
	for (unsigned factor : all_factors) {
		calc_result *= factor;
	}

	return calc_result;
}


LCM::~LCM() {
	delete[] set_of_numbers;
	delete[] arg_copy;
}
