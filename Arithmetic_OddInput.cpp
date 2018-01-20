// Arithmetic.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "OddNumbers.h"

#include <iostream>
#include <sstream>

using namespace std;


int main() {
	try {

		cout << "\n    Welcome to our demonstration sequels\n";
		cout << "Hope you enjoy (and follow) the lessons.\n\n";


		unsigned int start = 1, stop = 100;

		/*
		* Collect Input
		*/
		string user_str;
		cout << "\n\n" << "Enter the range for your odd numbers.\n";

		cout << "Enter Start Number: ";
		getline(cin, user_str); // Used for collecting user input.
		stringstream(user_str) >> start;

		cout << "Enter Stop Number: ";
		getline(cin, user_str);
		stringstream(user_str) >> stop;

		OddNumbers io_list(start, stop);
		cout << "\n" << io_list.prepResult() << "\n";

	}	catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}
    return 0;
}

