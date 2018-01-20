// Arithmetic.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "FastHCF.h"

#include <iostream>
#include <vector>
#include <string>
#include <sstream>
#include <regex>

using namespace std;

int main() {
    try {
        cout << "\n    Welcome to our demonstration sequels\n";
        cout << "Hope you enjoy (and follow) the lessons.\n\n";

        vector<unsigned> set;

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
                    } else {
                        cout << "\nYou cannot enter zero. Repeat that!\nType 'done' when you're finished.\n";
                    }
                } else if (user_input != "DONE") {
                    cout << "\nWrong Input. Repeat that!\nType 'done' when you're finished.\n";
                }
            } while (user_input != "DONE");
        } catch (exception& ex) {
            throw "Bad Input";
        }

        stringstream aux;
        string render_result = "The HCF of ";

        for (int number : set) {
            aux.str("");
            aux << number;
            render_result += aux.str() + "; ";
        }
        render_result += "is: ";

        // use the fast class to create object
        FastHCF h_c_f(set);
        cout << "\n\n" << render_result << h_c_f.getHCF() << "\n";

    } catch (exception& e) {
        cout << "\n" << e.what() << "\n";
    }
    return 0;
}

