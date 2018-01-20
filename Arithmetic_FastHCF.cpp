// Arithmetic.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "FastHCF.h"

#include <iostream>
#include <sstream>
#include <vector>

using namespace std;

int main() {
    try {
        cout << "\n    Welcome to our demonstration sequels\n";
        cout << "Hope you enjoy (and follow) the lessons.\n\n";

        vector<unsigned> set;

        /*
         * Find HCF.
         */
        string render_result = "The HCF of ";
        stringstream aux;

        vector<unsigned> set;
        set = {30, 48, 54};

        for (int number : set) {
            aux.str("");
            aux << number;
            render_result += aux.str() + "; ";
        }
        render_result += "is: ";

        // Use fast HCF
        FastHCF h_c_f(set);
        cout << "\n\n" << render_result << h_c_f.getHCF() << "\n";

    } catch (exception& e) {
        cout << "\n" << e.what() << "\n";
    }
    return 0;
}

