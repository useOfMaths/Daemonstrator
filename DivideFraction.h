#pragma once

#include "MultiplyFraction.h"

class DivideFraction : public MultiplyFraction {
public:
	DivideFraction(vector<unsigned>, vector<unsigned>);
	virtual ~DivideFraction();
	void doDivide();
};

