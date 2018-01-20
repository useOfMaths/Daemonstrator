#include "stdafx.h"
#include "Simultaneous2Unknown.h"


Simultaneous2Unknown::Simultaneous2Unknown(double x_coeff[], double y_coeff[], double eq[]) {
	x_coefficients[0] = x_coeff[0];
	x_coefficients[1] = x_coeff[1];
	y_coefficients[0] = y_coeff[0];
	y_coefficients[1] = y_coeff[1];
	equals[0] = eq[0];
	equals[1] = eq[1];
}

void Simultaneous2Unknown::solveSimultaneous() {
	// STEP 2:
	eliminator[0][0] = y_coefficients[1] * x_coefficients[0];
	eliminator[0][1] = y_coefficients[1] * equals[0];
	// STEP 3:
	eliminator[1][0] = y_coefficients[0] * x_coefficients[1];
	eliminator[1][1] = y_coefficients[0] * equals[1];

	try {
		if (eliminator[0][0] - eliminator[1][0] == 0) throw 0;
		// STEPS 4, 5:
		x_variable = (eliminator[0][1] - eliminator[1][1]) / (eliminator[0][0] - eliminator[1][0]);
		if (y_coefficients[0] == 0) throw 0;
		// STEP 6:
		y_variable = (equals[0] - x_coefficients[0] * x_variable) / y_coefficients[0];
	}
	catch (double e) {
		throw e;
	}
}

Simultaneous2Unknown::~Simultaneous2Unknown()
{
}
