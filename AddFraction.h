#pragma once

#include "LCM.h"

#include <vector>
using namespace std;

class AddFraction {
public:
	AddFraction(vector<unsigned>, vector<unsigned>);
	virtual ~AddFraction();
	void doAdd();
	unsigned int answer;
	unsigned int lcm;
protected:
	vector<unsigned> numerators;
	vector<unsigned> denominators;
	vector<unsigned> new_numerators;
	void canonizeFraction();
};

