#include "stdafx.h"
#include "ImproperToMixed.h"


ImproperToMixed::ImproperToMixed(unsigned num, unsigned denom) {
	numerator = num;
	denominator = denom;
}

void ImproperToMixed::doConvert() {
	int dividend; // Highest multiple of denominator less than numerator
	// STEP 1:
	for (dividend = numerator - 1; dividend > 1; dividend--) {
		if ((dividend % denominator) == 0) {
			// STEP 2:
			new_numerator = numerator - dividend;
			// STEP 3:
			whole_number = dividend / denominator;
			break;
		}
	}
}


ImproperToMixed::~ImproperToMixed() {
}
