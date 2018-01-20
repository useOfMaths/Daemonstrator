// Arithmetic.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "LCM.h"

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
         * Find L.C.M
         */
        set = {2, 5, 7};

        stringstream aux;
        string render_result = "The LCM of ";
        for (unsigned number : set) {
            aux.str("");
            aux << number;
            render_result += aux.str() + "; ";
        }
        render_result += " is:  ";

        LCM lcm(set);
        cout << "\n\n" << render_result << lcm.getLCM() << "\n";

    } catch (exception& e) {
        cout << "\n" << e.what() << "\n";
    }
    return 0;
}

