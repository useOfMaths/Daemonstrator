#pragma once

class LowestTerm {
public:
	LowestTerm(unsigned, unsigned);
	virtual ~LowestTerm();

	void reduceFraction();

	unsigned int numerator;
	unsigned int denominator;
private:
	unsigned int trial_factor;
};

