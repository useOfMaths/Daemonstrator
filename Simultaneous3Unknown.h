#pragma once

#include "Simultaneous2Unknown.h"
#include "LCM.h"
#include <vector>

class Simultaneous3Unknown {
public:
	Simultaneous3Unknown(int[], int[], int[], int[]);
	virtual ~Simultaneous3Unknown();
	void solveSimultaneous();
	double x_variable;
	double y_variable;
	double z_variable;
private:
	int x_coefficients[3];
	int y_coefficients[3];
	int z_coefficients[3];
	int equals[3];
	double eliminator[3][3];

};

