#pragma once

#include <iostream>
#include <algorithm>
#include <vector>
#include <string>
#include <math.h>

using namespace std;

class FastHCF {
public:
	FastHCF(vector<unsigned>);
	virtual ~FastHCF();
	unsigned getHCF(void);
private:
	int onlyPrimeFactors(unsigned);
	int findHCFFactors(void);

	int * set_of_numbers;
	int * arg_copy;
	size_t array_length;
	vector<unsigned> common_factors; // factors common to our set_of_numbers
	vector<unsigned> minimal_prime_factors;
	unsigned int index; // index into array common_factors
	bool all_round_factor; // variable to keep state
	unsigned int calc_result; // helps calculate HCF
};

