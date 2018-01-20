// Algebra.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "ImproperToMixed.h"

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
		* Convert fractions from Improper to Mixed
		*/
		numerator = 10;
		denominator = 3;

		cout << "\n    Converting from Improper to Mixed the fraction:\n";
		// Print as fraction
		printf("%56u\n", numerator);
		printf("%56s\n", "-");
		printf("%56u\n", denominator);

		// use the ImproperToMixed class
		ImproperToMixed imp_mix(numerator, denominator);
		imp_mix.doConvert();

		printf("\n%52u\n", imp_mix.new_numerator);
		printf("%50s%u%s\n", "Answer =   ", imp_mix.whole_number, "-");
		printf("%52u\n", denominator);

		cout << "\n\n";

	} catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}

    return 0;
}

