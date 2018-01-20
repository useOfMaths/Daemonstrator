#pragma once

#include <iostream>
#include <vector>
#include <string>
#include <sstream>
#include <math.h>

using namespace std;

class ListPrimeFactors {
public:
	ListPrimeFactors(unsigned);
	virtual ~ListPrimeFactors();
	string getPrimeFactors(void);
private:
	int onlyPrimeFactors(int);

	vector<unsigned> found_prime_factors;
	unsigned int find_my_factors;
	string render_factors;
	unsigned int i;
	string result;
	stringstream aux;
};

