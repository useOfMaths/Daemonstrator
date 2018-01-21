#include "stdafx.h"
#include "Permutation.h"

Permutation::Permutation() : Combination()
{
}

// till the ground for shuffle to grind on
vector<vector<string>> Permutation::possibleWordPermutations(vector<string> candidates, unsigned short dimension) {
	perm_store = {};
	possibleWordCombinations(candidates, dimension);
	// illegal 'r' value
	if (comb_store.empty() || r == 1) {
		perm_store = comb_store;
	}
	else {
		vector<vector<string>> last_two = { {"", ""}, {"", ""} };
		for (unsigned i = 0; i < comb_store.size(); i++) {
			index = r - 1;
			// copy up last two elements of 'comb_store.get(i)'
			last_two[0][0] = last_two[1][1] = comb_store[i][index--];
			last_two[0][1] = last_two[1][0] = comb_store[i][index--];

			local_store = {};
			local_store.push_back(last_two[0]);
			local_store.push_back(last_two[1]);
			if (r > 2) {
				shuffleWord(local_store, i);
			}
			// add to final comb_store
			for (vector<string> part : local_store) {
				perm_store.push_back(part);
			}
		}
	}
	return perm_store;
}

void Permutation::shuffleWord(vector<vector<string>> arg_store, unsigned i) {
	local_store = {};
	vector<string> members;
	for (unsigned j = 0; j < arg_store.size(); j++) {
		members = arg_store[j];
		// add 'index' 'comb_store[i]' element to this list of members
		members.push_back(comb_store[i][index]);

		int shift_index = members.size();
		// shuffle this pack of words
		while (shift_index > 0) {
			vector<vector<string>>::iterator iter;
			iter = search(local_store.begin(), local_store.end(), &members, &members + 1);
			// skip if already in store
			if (iter == local_store.end()) {
				local_store.push_back(members);
			}
			// interchange these two neighbours
			if (--shift_index > 0 && members[shift_index] != members[shift_index - 1]) {
				swap(members[shift_index - 1], members[shift_index]);
			}
		}
	}
	// Are there any elements left? repeat if yes
	if (index-- > 0) {
		shuffleWord(local_store, i);
	}
}


Permutation::~Permutation()
{
}
