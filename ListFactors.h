#pragma once

#include <iostream>
#include <math.h>
#include <algorithm>
#include <vector>
#include <string>
#include <sstream>

using namespace std;

class ListFactors {
public:
	ListFactors(unsigned);
	virtual ~ListFactors();
	string doBusiness();
private:
	vector<unsigned> found_factors;
	unsigned int find_my_factors;
	unsigned int sqrt_range; // Use this range for our loop
	string result;
	stringstream aux;
};

