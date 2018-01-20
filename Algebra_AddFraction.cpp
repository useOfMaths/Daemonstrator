// Algebra.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "AddFraction.h"

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
		* Adding fractions
		*/
		numerators = { 1, 1, 1, 1 };
		denominators = { 4, 4, 4, 4 };

		cout << "\n    Solving:\n";
		// Print as fraction
		for (unsigned n : numerators) {
			printf("%13u", n);
		}
		printf("\n%12s", " ");
		for (unsigned i = 0; i < numerators.size() - 1; i++) {
			cout << "-     +      ";
		}
		printf("%2s\n", "-");
		for (unsigned d : denominators) {
			printf("%13u", d);
		}
		cout << "\n";

		// use the AddFraction class
		AddFraction add_fract(numerators, denominators);
		add_fract.doAdd();

		printf("\n%26u\n", add_fract.answer);
		printf("%26s\n", "Answer =     -");
		printf("%26u\n", add_fract.LCM);

		cout << "\n\n";

	} catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}

    return 0;
}

