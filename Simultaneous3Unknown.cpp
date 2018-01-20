#include "stdafx.h"
#include "Simultaneous3Unknown.h"


Simultaneous3Unknown::Simultaneous3Unknown(int x_coeff[], int y_coeff[], int z_coeff[], int eq[]) {
	for (unsigned i = 0; i < 3; i++) {
		x_coefficients[i] = x_coeff[i];
		y_coefficients[i] = y_coeff[i];
		z_coefficients[i] = z_coeff[i];
		equals[i] = eq[i];
	}
}

void Simultaneous3Unknown::solveSimultaneous() {
	int lcm;
	vector<unsigned> z_arg = {
		(unsigned)abs(z_coefficients[0]),
		(unsigned)abs(z_coefficients[1]),
		(unsigned)abs(z_coefficients[2])
	};
	LCM l_c_m(z_arg);
	lcm = l_c_m.getLCM();

	// STEP 1:
	eliminator[0][0] = (lcm * x_coefficients[0]) / z_coefficients[0];
	eliminator[0][1] = (lcm * y_coefficients[0]) / z_coefficients[0];
	eliminator[0][2] = (lcm * equals[0]) / z_coefficients[0];

	eliminator[1][0] = (lcm * x_coefficients[1]) / z_coefficients[1];
	eliminator[1][1] = (lcm * y_coefficients[1]) / z_coefficients[1];
	eliminator[1][2] = (lcm * equals[1]) / z_coefficients[1];

	eliminator[2][0] = (lcm * x_coefficients[2]) / z_coefficients[2];
	eliminator[2][1] = (lcm * y_coefficients[2]) / z_coefficients[2];
	eliminator[2][2] = (lcm * equals[2]) / z_coefficients[2];

	// STEP 2:
	double new_x[] = {
		eliminator[0][0] - eliminator[1][0],
		eliminator[1][0] - eliminator[2][0]
	};
	double new_y[] = {
		eliminator[0][1] - eliminator[1][1],
		eliminator[1][1] - eliminator[2][1]
	};
	double new_eq[] = {
		eliminator[0][2] - eliminator[1][2],
		eliminator[1][2] - eliminator[2][2]
	};

	try {
		// STEP 3
		Simultaneous2Unknown s2u(new_x, new_y, new_eq);
		s2u.solveSimultaneous();

		x_variable = s2u.x_variable;
		y_variable = s2u.y_variable;
		if (z_coefficients[0] == 0) throw 0;
		// STEP 4:
		z_variable = (equals[0] - x_coefficients[0] * x_variable - y_coefficients[0] * y_variable) / z_coefficients[0];
	}
	catch (int e) {
		throw e;
	}
}

Simultaneous3Unknown::~Simultaneous3Unknown()
{
}
