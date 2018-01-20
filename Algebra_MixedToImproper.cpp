// Algebra.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "MixedToImproper.h"

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
		* Convert fractions from Mixed to Improper
		*/
		whole_number = 3;
		numerator = 1;
		denominator = 3;

		cout << "    Converting from Mixed to Improper the fraction:\n";
		// Print as fraction
		printf("%55u\n", numerator);
		printf("%54u%s\n", whole_number, "-");
		printf("%55u\n", denominator);

		// use the MixedToImproper class
		MixedToImproper mix_imp(whole_number, numerator, denominator);
		numerator = mix_imp.doConvert();

		cout << "\n";

		printf("%53u\n", numerator);
		printf("%53s\n", "Answer =   -");
		printf("%53u\n", denominator);

		cout << "\n\n";

	} catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}

    return 0;
}

