// Algebra.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "LowestTerm.h"

#include <iostream>
#include <exception>

using namespace std;

int main()
{
	cout << "\n    Welcome to our demonstration sequels";
	cout << "\n    Hope you enjoy (and follow) the lessons.\n\n";

	unsigned int numerator;
	unsigned int denominator;
	unsigned int whole_number;

	try {
		/*
		* Reduce fractions to Lowest Term
		*/
		numerator = 16;
		denominator = 640;

		cout << "\n    To reduce to lowest term, simplifying:\n";
		// Print as fraction
		printf("%46u\n", numerator);
		printf("%46s\n", "-");
		printf("%46u\n", denominator);

		// use the LowestTerm class
		LowestTerm red_fract(numerator, denominator);
		red_fract.reduceFraction();

		printf("\n%46u\n", red_fract.numerator);
		printf("%46s\n", "Answer =    -");
		printf("%46u\n", red_fract.denominator);

		cout << "\n\n";

	} catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}

    return 0;
}

