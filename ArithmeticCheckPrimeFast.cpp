// Arithmetic.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "CheckPrimeFast.h"

#include <iostream>

using namespace std;


int main() {
	try {

		cout << "\n    Welcome to our demonstration sequels\n";
		cout << "Hope you enjoy (and follow) the lessons.\n\n";


		unsigned int start = 1, stop = 100;

		/*
		* Use the Test Prime class.
		*/
		CheckPrimeFast answer(98);
		// Try the fast version
		cout << "\n" << answer.verifyPrimeFast() << "\n";

	}	catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}
    return 0;
}

