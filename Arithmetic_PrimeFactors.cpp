// Arithmetic.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "ListPrimeFactors.h"

#include <iostream>

using namespace std;


int main() {
	try {

		cout << "\n    Welcome to our demonstration sequels\n";
		cout << "Hope you enjoy (and follow) the lessons.\n\n";


		unsigned int start = 1, stop = 100;

		/*
		* Prime factors of a number.
		*/
		ListPrimeFactors pf_list(48);
		cout << "\n\n" << pf_list.getPrimeFactors() << "\n";

	}	catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}
    return 0;
}

