#include "stdafx.h"
#include "MultiplyFraction.h"


MultiplyFraction::MultiplyFraction(vector<unsigned> num, vector<unsigned> denom) {
	numerators = num;
	denominators = denom;
	trial_factor = 0;
	n_index = 0;
	d_index = 0;
	answer[0] = 1;
	answer[1] = 1;

	for (unsigned n : num) {
		if (n > trial_factor) {
			trial_factor = n;
		}
	}
	for (unsigned d : denom) {
		if (d > trial_factor) {
			trial_factor = d;
		}
	}
}

void MultiplyFraction::doMultiply() {
	// STEP 3:
	// We are counting down to test for mutual factors 
	while (trial_factor > 1) {
		// STEP 1:
		// iterate through numerators and check for factors
		while (n_index < numerators.size()) {
			mutual_factor = false;
			if ((numerators[n_index] % trial_factor) == 0) { // do we have a factor
															 // iterate through denominators and check for factors
				while (d_index < denominators.size()) {
					if ((denominators[d_index] % trial_factor) == 0) { // is this factor mutual?
						mutual_factor = true;
						break; // stop as soon as we find a mutual factor so preserve the corresponding index
					}
					d_index++;
				}
				break; // stop as soon as we find a mutual factor so as  preserve the corresponding index
			}
			n_index++;
		}
		// STEP 2:
		// where we have a mutual factor
		if (mutual_factor) {
			numerators[n_index] /= trial_factor;
			denominators[d_index] /= trial_factor;
			continue; // continue with next iteration repeating the current value of trial_factor
		}
		n_index = 0;
		d_index = 0;
		trial_factor--;
	}

	for (int i = 0; i < numerators.size(); i++) {
		answer[0] *= numerators[i];
		answer[1] *= denominators[i];
	}
}


MultiplyFraction::~MultiplyFraction() {
}
