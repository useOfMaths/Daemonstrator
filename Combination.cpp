#include "stdafx.h"
#include "Combination.h"


Combination::Combination()
{
}

// point of entry
vector<vector<string>> Combination::possibleWordCombinations(vector<string> candidates, unsigned short dimension) {
	words = candidates;
	r = dimension;
	comb_store = {};
	i = 0;
	// check for conformity
	if (r <= 0 || r > words.size()) {
		comb_store = {};
	}
	else if (r == 1) {
		for (; i < words.size(); i++) {
			comb_store.push_back({words[i]});
		}
	}
	else {
		progressiveCombination();
	}
	return comb_store;
}

// do combinations for all 'words' element
void Combination::progressiveCombination() {
	//        single member list
	repetitivePairing({words[i]}, i + 1);
	if (i + r <= words.size()) {
		// move on to next degree
		i++;
		progressiveCombination();
	}
}

// do all possible combinations for 1st element of this array
void Combination::repetitivePairing(vector<string> prefix, unsigned position) {
	vector<string> * auxiliary_store;
	auxiliary_store = new vector<string>[words.size() - position];
	for (unsigned j = 0; position < words.size(); position++, j++) {
		// check if desired -- r -- size will be realised
		if (j + i + r <= words.size()) {
			auxiliary_store[j] = prefix;
			auxiliary_store[j].push_back(words[position]);
			if (auxiliary_store[j].size() < r) {
				// see to adding next word on
				repetitivePairing(auxiliary_store[j], position + 1);
			}
			else {
				comb_store.push_back(auxiliary_store[j]);
			}
		}
	}
	delete[] auxiliary_store; // memory friendly
	comb_store.shrink_to_fit();
}

Combination::~Combination()
{
}
