#pragma once

#include "AddFraction.h"

class SubtractFraction : public AddFraction {
public:
	SubtractFraction(vector<unsigned>, vector<unsigned>);
	virtual ~SubtractFraction();
	void doSubtract(void);
};

