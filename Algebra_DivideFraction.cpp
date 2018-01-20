// Algebra.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "DivideFraction.h"

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
		* Dividing fractions
		*/
		numerators = { 16, 9, 640, 7 };
		denominators = { 9, 20, 27, 20 };

		cout << "\n    Solving:\n";
		// Print as fraction
		for (unsigned n : numerators) {
			printf("%13u", n);
		}
		printf("\n%12s", " ");
		for (unsigned i = 0; i < numerators.size() - 1; i++) {
			cout << "-     /      ";
		}
		printf("%2s\n", "-");
		for (unsigned d : denominators) {
			printf("%13u", d);
		}
		cout << "\n";

		// use the DivideFraction class
		DivideFraction div_fract(numerators, denominators);
		div_fract.doDivide();

		printf("\n%25u\n", div_fract.answer[0]);
		printf("%25s\n", "Answer =    -");
		printf("%25u\n", div_fract.answer[1]);

		cout << "\n\n";

	} catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}

    return 0;
}

