#include "stdafx.h"
#include "MixedToImproper.h"


MixedToImproper::MixedToImproper(unsigned whole_num, unsigned num, unsigned denom) {
	whole_number = whole_num;
	numerator = num;
	denominator = denom;
}

int MixedToImproper::doConvert() {
	// STEPS 1, 2:
	return (whole_number * denominator) + numerator;
}


MixedToImproper::~MixedToImproper() {
}
