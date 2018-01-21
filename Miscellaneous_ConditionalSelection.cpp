#include "stdafx.h"
#include "ConditionalSelection.h"
#include <vector>

#include <iostream>

using namespace std;

int main()
{
	vector<string> goods = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
	unsigned short min_occurrence[]{ 0, 0, 1, 0, 0, 1, 0, 0, 1, 0 };
	unsigned short max_occurrence[]{ 4, 3, 2, 4, 3, 2, 4, 3, 2, 4 };
	ConditionalSelection choose;
	vector<vector<string>> result = choose.limitedSelection(goods, 4, min_occurrence, max_occurrence);
	// print choices and operation
	cout << "\n[ ";
	for (string choice : choose.words) {
		cout << choice << "; ";
	}
	cout << "] conditioned selection " << choose.r << ":\n\n";

	// print out selections nicely
	for (vector<string> set : result) {
		for (string member : set) {
			cout << member << "; ";
		}
		cout << "\n";
	}
	cout << "\nNumber of ways is " << result.size() << ".";

	return 0;
}

