// Algebra.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "MultiplyFraction.h"

#include <iostream>
#include <vector>
#include <exception>

using namespace std;

int main()
{
	cout << "\n    Welcome to our demonstration sequels";
	cout << "\n    Hope you enjoy (and follow) the lessons.\n\n";

	vector<unsigned> numerators;
	vector<unsigned> denominators;

	try {
		/*
		* Multiplying fractions
		*/
		numerators = { 16, 20, 27, 20 };
		denominators = { 9, 9, 640, 7 };

		cout << "\n    Solving:\n";
		// Print as fraction
		for (unsigned n : numerators) {
			printf("%13u", n);
		}
		printf("\n%12s", " ");
		for (unsigned i = 0; i < numerators.size() - 1; i++) {
			cout << "-     X      ";
		}
		printf("%1s", "-");
		cout << "\n";
		for (unsigned d : denominators) {
			printf("%13u", d);
		}
		cout << "\n";

		// use the MultiplyFraction class
		MultiplyFraction mul_fract(numerators, denominators);
		mul_fract.doMultiply();

		printf("\n%26u\n", mul_fract.answer[0]);
		printf("%26s\n", "Answer =      -");
		printf("%26u\n", mul_fract.answer[1]);

		cout << "\n\n";

	} catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}

    return 0;
}

