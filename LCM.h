#pragma once

#include <iostream>
#include <algorithm>
#include <vector>
#include <string>

using namespace std;

class LCM {
public:
	LCM(vector<unsigned>);
	virtual ~LCM();
	unsigned getLCM(void);
private:
	int LCMFactors(void);

	unsigned * set_of_numbers;
	unsigned * arg_copy; // Java passes arrays by reference; make a copy.
	size_t array_length;
	vector<unsigned> all_factors; // factors common to our set_of_numbers

	unsigned int index; // index into array common_factors
	bool state_check; // variable to keep state
	unsigned int calc_result;
};

