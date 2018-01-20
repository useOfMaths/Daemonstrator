// Algebra.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Simultaneous2Unknown.h"

#include <iostream>
#include <vector>
#include <exception>

using namespace std;

int main() {

	cout << "\n    Welcome to our demonstration sequels";
	cout << "\n    Hope you enjoy (and follow) the lessons.\n\n";

	vector<unsigned> numerators;
	vector<unsigned> denominators;

	try {
		/*
		* Simultaneous Equations with 2 unknowns
		*/
		char * infinity = "infinity";
		char operators2D[]{ '+', '+' };
		double x_coeff2D[]{ 2, 1 };
		double y_coeff2D[]{ -1, 1 };
		double equals2D[]{ 1, 2 };

		if (y_coeff2D[0] < 0) {
			operators2D[0] = '-';
		}
		if (y_coeff2D[1] < 0) {
			operators2D[1] = '-';
		}

		cout << "\n    Solving simultaneously the equations:\n";
		//Print as an equation
		printf("%40.2fx %c %.2fy = %.2f\n", x_coeff2D[0], operators2D[0], abs(y_coeff2D[0]), equals2D[0]);
		printf("%40.2fx %c %.2fy = %.2f\n", x_coeff2D[1], operators2D[1], abs(y_coeff2D[1]), equals2D[1]);
		printf("\n%30s\n%40s", "Yields:", "(x, y)  =  ");

		try {
			Simultaneous2Unknown sim2unk(x_coeff2D, y_coeff2D, equals2D);
			sim2unk.solveSimultaneous();

			printf("(%.4f, %.4f)\n", sim2unk.x_variable, sim2unk.y_variable);

		}
		catch (...) {
			printf("(%s, %s)\n", infinity, infinity);
		}

		cout << "\n\n";

	} catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}

    return 0;
}

