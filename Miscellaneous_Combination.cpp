#include "stdafx.h"
#include "Combination.h"
#include <vector>

#include <iostream>

using namespace std;

int main()
{
	vector<string> goods = { "Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda" };
	Combination combo;
	vector<vector<string>> result = combo.possibleWordCombinations(goods, 3);
	// print choices and operation
	cout << "\n[";
	for (string choice : combo.words) {
		cout << choice << "; ";
	}
	cout << "] combination " << combo.r << ":\n\n";

	// print out combinations nicely
	for (vector<string> set : result) {
		for (string member : set) {
			cout << member << "; ";
		}
		cout << "\n";
	}
	cout << "\nNumber of ways is " << result.size() << ".";

    return 0;
}

