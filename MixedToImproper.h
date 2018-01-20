#pragma once

class MixedToImproper {
public:
	MixedToImproper(unsigned, unsigned, unsigned);
	virtual ~MixedToImproper();
	int doConvert();
private:
	unsigned int numerator;
	unsigned int denominator;
	unsigned int whole_number;
};

