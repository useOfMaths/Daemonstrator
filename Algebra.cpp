// Algebra.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Simultaneous3Unknown.h"

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
		* Simultaneous Equations with 3 unknowns
		*/
		wchar_t infinity = '\U00000097';
		char operators3D[3][2];

		int x_coeff3D[]{ 2, 4, 2 };
		int y_coeff3D[]{ 1, -1, 3 };
		int z_coeff3D[]{ 1, -2, -8 };
		int equals3D[]{ 4, 1, -3 };

		for (int i = 0; i < 3; i++) {
			operators3D[i][0] = '+';
			if (y_coeff3D[i] < 0) {
				operators3D[i][0] = '-';
			}
			operators3D[i][1] = '+';
			if (z_coeff3D[i] < 0) {
				operators3D[i][1] = '-';
			}
		}

		cout << "\n    Solving simultaneously the equations:\n";
		// Print as an equation
		printf(
			"%40dx %c %dy %c %dz = %d\n", x_coeff3D[0], operators3D[0][0],
			abs(y_coeff3D[0]), operators3D[0][1], abs(z_coeff3D[0]), equals3D[0]
		);
		printf(
			"%40dx %c %dy %c %dz = %d\n", x_coeff3D[1], operators3D[1][0],
			abs(y_coeff3D[1]), operators3D[1][1], abs(z_coeff3D[1]), equals3D[1]
		);
		printf(
			"%40dx %c %dy %c %dz = %d\n", x_coeff3D[2], operators3D[2][0],
			abs(y_coeff3D[2]), operators3D[2][1], abs(z_coeff3D[2]), equals3D[2]
		);
		printf("\n%30s\n%40s", "Yields:", "(x, y, z)  =  ");

		try {
			Simultaneous3Unknown sim3unk(x_coeff3D, y_coeff3D, z_coeff3D, equals3D);
			sim3unk.solveSimultaneous();

			printf("(%.4f, %.4f, %.4f)\n", sim3unk.x_variable, sim3unk.y_variable, sim3unk.z_variable);

		}
		catch (...) {
			printf("(%c, %c, %c)\n", infinity, infinity, infinity);
		}

		cout << "\n\n";

	} catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}

    return 0;
}

