#pragma once
#include <iostream>
#include <exception>

class Simultaneous2Unknown {
public:
	Simultaneous2Unknown(double[], double[], double[]);
	void solveSimultaneous();
	double x_variable;
	double y_variable;
	virtual ~Simultaneous2Unknown();
private:
	double x_coefficients[2];
	double y_coefficients[2];
	double equals[2];
	double eliminator[2][2];
};
