#include "stdafx.h"
#include "AddFraction.h"


AddFraction::AddFraction(vector<unsigned> num, vector<unsigned> denom) {
	numerators = num;
	denominators = denom;
	answer = 0;
}

void AddFraction::canonizeFraction() {
	// find their LCM
	LCM l_c_m(denominators);
	lcm = l_c_m.getLCM();

	// transform fractions so they all have same denominator
	for (unsigned i = 0; i < denominators.size(); i++) {
		new_numerators.push_back(lcm / denominators[i] * numerators[i]);
	}
	new_numerators.shrink_to_fit();
}

void AddFraction::doAdd() {
	canonizeFraction();

	// add all transformed numerators
	for (unsigned i = 0; i < new_numerators.size(); i++) {
		answer += new_numerators[i];
	}
}


AddFraction::~AddFraction() {
}
