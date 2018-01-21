#include "stdafx.h"
#include "Selection.h"
#include <vector>

#include <iostream>

using namespace std;

int main()
{
	vector<string> goods = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
	Selection pick;
	vector<vector<string>> result = pick.groupSelection(goods, 2);
	// print choices and operation
	cout << "\n[ ";
	for (string choice : pick.words) {
		cout << choice << "; ";
	}
	cout << "] selection " << pick.r << ":\n\n";

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

