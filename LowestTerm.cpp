#include "stdafx.h"
#include "LowestTerm.h"


LowestTerm::LowestTerm(unsigned num, unsigned denom) {
	numerator = num;
	denominator = denom;

	num < denom ? trial_factor = num : trial_factor = denom;
}

void LowestTerm::reduceFraction() {
	// We are counting down to test for mutual factors 
	while (trial_factor > 1) {
		// do we have a factor
		if ((numerator % trial_factor) == 0) {
			// is this factor mutual?
			if ((denominator % trial_factor) == 0) {
				// where we have a mutual factor
				numerator /= trial_factor;
				denominator /= trial_factor;
				continue; // continue with next iteration, repeating the current value of trial_factor
			}
		}
		trial_factor--;
	}
}


LowestTerm::~LowestTerm() {
}
