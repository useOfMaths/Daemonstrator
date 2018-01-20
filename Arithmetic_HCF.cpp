// Arithmetic.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "HCF.h"

#include <iostream>
#include <vector>
#include <sstream>

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

        set = {30, 48, 54};

        for (int number : set) {
            aux.str("");
            aux << number;
            render_result += aux.str() + "; ";
        }
        render_result += "is: ";

        HCF hcf(set);
        cout << "\n\n" << render_result << hcf.getHCF() << "\n";

    } catch (exception& e) {
        cout << "\n" << e.what() << "\n";
    }
    return 0;
}

