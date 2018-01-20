// Arithmetic.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "OddNumbers.h"

#include <iostream>

using namespace std;


int main() {
	try {

		cout << "\n    Welcome to our demonstration sequels\n";
		cout << "Hope you enjoy (and follow) the lessons.\n\n";


		unsigned int start = 1, stop = 100;

		/*
		* Use the odd number class.
		*/
		OddNumbers o_list(start, stop); // using start and stop values as from before
		cout << "\n\n" << o_list.prepResult() << "\n";

	}	catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}
    return 0;
}

