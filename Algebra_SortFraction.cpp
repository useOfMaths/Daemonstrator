// Algebra.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "SortFraction.h"

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
		* Sorting fractions
		*/
		numerators = { 1, 3, 5, 9 };
		denominators = { 2, 4, 2, 10 };

		cout << "\n    Sorting in ascending order the fractions:\n";
		// Print as fraction
		printf("%35s", " ");
		for (unsigned n : numerators) {
			printf("%9u", n);
		}
		printf("\n%43s", " ");
		for (unsigned i = 0; i < numerators.size() - 1; i++) {
			cout << "- ,      ";
		}
		printf("%2s", "-");
		printf("\n%35s", " ");
		for (unsigned d : denominators) {
			printf("%9d", d);
		}
		cout << "\n";

		// use the SortFraction class
		SortFraction sort_fract(numerators, denominators);
		sort_fract.sortAscending();
		numerators = sort_fract.final_numerators;
		denominators = sort_fract.final_denominators;

		// Print as fraction
		printf("\n%35s", " ");
		for (unsigned n : numerators) {
			printf("%9u", n);
		}
		printf("\n%43s", "Answer =    ");
		for (unsigned i = 0; i < numerators.size() - 1; i++) {
			cout << "- ,      ";
		}
		printf("%2s", "-");
		printf("\n%35s", " ");
		for (unsigned d : denominators) {
			printf("%9u", d);
		}

		cout << "\n\n";

	} catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}

    return 0;
}

