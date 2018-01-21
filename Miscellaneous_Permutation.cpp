#include "stdafx.h"
#include "Permutation.h"
#include <vector>

#include <iostream>

using namespace std;

int main()
{
	vector<string> goods = { "Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda" };
	Permutation perm;
	vector<vector<string>> result = perm.possibleWordPermutations(goods, 3);
	// print choices and operation
	cout << "\n[ ";
	for (string choice : perm.words) {
		cout << choice << "; ";
	}
	cout << "] permutation " << perm.r << ":\n\n";

	// print out permutations nicely
	for (vector<string> set : result) {
		for (string member : set) {
			cout << member << "; ";
		}
		cout << "\n";
	}
	cout << "\nNumber of ways is " << result.size() << ".";

    return 0;
}

