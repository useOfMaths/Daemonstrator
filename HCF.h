#pragma once

#include <iostream>
#include <algorithm>
#include <vector>
#include <string>

using namespace std;

class HCF {
public:
	HCF(vector<unsigned>);
	virtual ~HCF();
	unsigned getHCF(void);
private:
	int HCFFactors(void);

	int * set_of_numbers;
	size_t array_length;
	vector<unsigned> common_factors; // factors common to our set_of_numbers
	unsigned int index; // index into array common_factors
	bool all_round_factor; // variable to keep state
	unsigned int calc_result; // helps calculate HCF
};

