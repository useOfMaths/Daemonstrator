#pragma once

#include <vector>
using namespace std;

class MultiplyFraction {
public:
	MultiplyFraction(vector<unsigned>, vector<unsigned>);
	virtual ~MultiplyFraction();
	void doMultiply();

	unsigned int answer[2];
protected:
	vector<unsigned> numerators;
	vector<unsigned> denominators;
	unsigned int n_index, d_index;
	unsigned int trial_factor;
	bool mutual_factor;
};

