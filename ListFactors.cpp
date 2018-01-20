#include "stdafx.h"
#include "ListFactors.h"


ListFactors::ListFactors(unsigned candidate) {
	found_factors = { 1, candidate };
	find_my_factors = candidate;
	sqrt_range = (int)ceil(sqrt(find_my_factors));
	result = "The factors of ";
}

/**
* Does the main job of finding the requested factors.
*/
string ListFactors::doBusiness() {
	/* Loop through 1 to 'find_my_factors' and test for divisibility. */
	for (int i = 2; i < sqrt_range; i++) {
		if ((find_my_factors % i) == 0) {
			found_factors.push_back(i);
			/* Get the complementing factor by dividing 'find_my_factor' by variable i. */
			found_factors.push_back(find_my_factors / i);
		}
	}

	found_factors.shrink_to_fit();

	// Sort the array in ascending order; Not entirely necessary.
	sort(found_factors.begin(), found_factors.end());

	aux << find_my_factors;
	result += aux.str() + " are: \n";
	for (unsigned factor : found_factors) {
		aux.str("");
		aux << factor;
		result += aux.str() + "; ";
	}
	return result;
}


ListFactors::~ListFactors()
{
}
