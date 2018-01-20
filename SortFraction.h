#pragma once

#include "AddFraction.h"

#include <algorithm>

class SortFraction : AddFraction {
public:
	SortFraction(vector<unsigned>, vector<unsigned>);
	virtual ~SortFraction();
	void sortAscending();
	void sortDescending();
	vector<unsigned> final_numerators;
	vector<unsigned> final_denominators;
private:
	unsigned int index;
	vector<unsigned> copy_numerators;
	void introit();
	void finale();
};

