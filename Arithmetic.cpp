// Arithmetic.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "EvenNumbers.h"
#include "OddNumbers.h"
#include "CheckPrime.h"
#include "CheckPrimeFast.h"
#include "PrimeNumbers.h"/*
#include "ListFactors.h"
#include "ListPrimeFactors.h"
#include "HCF.h"
#include "FastHCF.h"
#include "LCM.h"*/

#include <iostream>/*
#include <string>
#include <sstream>
#include <regex>*/

using namespace std;


int main() {
	try {

		cout << "\n    Welcome to our demonstration sequels\n";
		cout << "Hope you enjoy (and follow) the lessons.\n\n";


		unsigned int start = 1, stop = 100;

		/*
		* Use the Even Number class.
		*//*
		EvenNumbers e_list(start, stop);
		cout << e_list.prepResult() << "\n";


		/*
		* Use the odd number class.
		*//*
		OddNumbers o_list(start, stop); // using start and stop values as from before
		cout << "\n\n" << o_list.prepResult() << "\n";


		/*
		* Collect Input
		*//*
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

		/*
		* Use the Check Prime class.
		*//*
		CheckPrime answer(98);
		cout << "\n\n" << answer.verifyPrime() << "\n";*/

		CheckPrimeFast result(98);
		// Try the fast version
		cout << "\n" << result.verifyPrimeFast() << "\n";

		/*
		* List of Prime Numbers.
		*//*
		PrimeNumbers p_list(start, stop);
		cout << "\n\nA result: " << p_list.getPrimes() << "\n";

		/*
		* Factors of a number.
		*//*
		ListFactors f_list(48);
		cout << "\n\n" << f_list.doBusiness() << "\n";

		/*
		* Prime factors of a number.
		*//*
		ListPrimeFactors pf_list(48);
		cout << "\n\n" << pf_list.getPrimeFactors() << "\n";

		/*
		* Find HCF.
		*//*
		vector<unsigned> set;
		set = { 30, 48, 54 };
		
		HCF HCF(set);
		cout << "\n\n" << HCF.getHCF() << "\n";
		
		
		// Use fast HCF
		FastHCF h_c_f(set);
		cout << "\n\n" << h_c_f.getHCF() << "\n";

		// Collect input
		cout << "\nWelcome to our Find HCF program.\n";
		cout << "Enter your series of numbers whose HCF you wish to find.\n";
		cout << "\nType 'done' when you are through with entering your numbers.\n";
		cout << "Enter First Number:  ";

		set = {};
		string user_input;
		int user_num;
		regex verify_num("([0-9]+)"); //Regular expression object
		try {
			do {
				// get keyboard input
				getline(cin, user_input);
				// Convert 'user_input' to upper case.
				transform(user_input.begin(), user_input.end(), user_input.begin(), ::toupper);
				// Make sure input is a number
				if (regex_match(user_input, verify_num)) {
					stringstream(user_input) >> user_num;
					if (user_num != 0) {
						set.push_back(user_num);
						cout << "Enter Next Number:  ";
					}
					else {
						cout << "\nYou cannot enter zero. Repeat that!\nType 'done' when you're finished.\n";
					}
				}
				else if (user_input != "DONE") {
					cout << "\nWrong Input. Repeat that!\nType 'done' when you're finished.\n";
				}
			} while (user_input != "DONE");
		}
		catch (exception& ex) {
			throw "Bad Input";
		}
		// use the fast class to create object
		FastHCF H_C_F(set);
		cout << "\n" << H_C_F.getHCF() << "\n";

		/*
		* Find L.C.M
		*//*
		//set.clear();
		//set.resize(3);
		set = { 2,5,7 };

		LCM LCM(set);
		cout << "\n\n" << LCM.getLCM() << "\n";*/

	}	catch (exception& e) {
		cout << "\n" << e.what() << "\n";
	}
    return 0;
}

