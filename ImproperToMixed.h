#pragma once

class ImproperToMixed {
public:
	ImproperToMixed(unsigned, unsigned);
	virtual ~ImproperToMixed();
	void doConvert();

	unsigned int numerator;
	unsigned int denominator;
	unsigned int whole_number;
	unsigned int new_numerator;
};

