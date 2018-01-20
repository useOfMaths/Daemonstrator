#include "stdafx.h"
#include "SortFraction.h"

// descending sort function
bool isGreater(unsigned i, unsigned j) { return i > j; }



SortFraction::SortFraction(vector<unsigned> num, vector<unsigned> denom) : AddFraction(num, denom) {
}

void SortFraction::introit() {
	// STEPS 1, 2:
	canonizeFraction();

	// copy numerators of transformed fractions
	for (unsigned nn : new_numerators) {
		copy_numerators.push_back(nn);
	}
	copy_numerators.shrink_to_fit();
}

void SortFraction::finale() {
	// map sorted (transformed) fractions to the original ones
	vector<unsigned>::iterator iter;
	for (unsigned sorted : copy_numerators) {
		iter = search(new_numerators.begin(), new_numerators.end(), &sorted, &sorted + 1);
		if (iter != new_numerators.end()) {
			index = iter - new_numerators.begin();
			final_numerators.push_back(numerators[index]);
			final_denominators.push_back(denominators[index]);
		}
	}
	final_numerators.shrink_to_fit();
	final_denominators.shrink_to_fit();
}

void SortFraction::sortAscending() {
	introit();
	// STEP 3:
	// Sort array in ascending order order
	sort(copy_numerators.begin(), copy_numerators.end());
	finale();
}

void SortFraction::sortDescending() {
	introit();
	// STEP 3:
	// Sort array in descending order order
	sort(copy_numerators.begin(), copy_numerators.end(), isGreater);
	finale();
}


SortFraction::~SortFraction() {
}
