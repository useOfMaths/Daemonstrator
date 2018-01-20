#include "stdafx.h"
#include "DivideFraction.h"


DivideFraction::DivideFraction(vector<unsigned> num, vector<unsigned> denom) : MultiplyFraction(num, denom) {
}

void DivideFraction::doDivide() {
	unsigned temp;
	// Invert every other fraction but the first
	for (unsigned i = 1; i < numerators.size(); i++) {
		temp = numerators[i];
		numerators[i] = denominators[i];
		denominators[i] = temp;
	}
	doMultiply();
}


DivideFraction::~DivideFraction() {
}
