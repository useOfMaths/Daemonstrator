#include "stdafx.h"
#include "SubtractFraction.h"


SubtractFraction::SubtractFraction(vector<unsigned> num, vector<unsigned> denom) : AddFraction(num, denom) {
}

void SubtractFraction::doSubtract() {
	// STEPS 1, 2:
	canonizeFraction();

	// STEP 3:
	// subtract all transformed numerators
	answer = new_numerators[0];
	for (unsigned i = 1; i < new_numerators.size(); i++) {
		answer -= new_numerators[i];
	}
}


SubtractFraction::~SubtractFraction() {
}
