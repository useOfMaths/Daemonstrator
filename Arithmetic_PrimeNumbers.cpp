// Arithmetic.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "PrimeNumbers.h"

#include <iostream>

using namespace std;


int main() {
	try {

		cout << "\n    Welcome to our demonstration sequels\n";
		cout << "Hope you enjoy (and follow) the lessons.\n\n";


		unsigned int start = 1, stop = 100;

		/*
		* List of Prime Numbers.
		*/
		PrimeNumbers p_list(start, stop);
		cout << "\n\n" << p_list.getPrimes() << "\n";

	}	catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}
    return 0;
}

