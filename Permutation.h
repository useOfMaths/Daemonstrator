#pragma once

#include "Combination.h"
#include <array>

class Permutation : public Combination
{
public:
	Permutation();
	virtual ~Permutation();
	vector<vector<string>> possibleWordPermutations(vector<string>, unsigned short);
	void shuffleWord(vector<vector<string>>, unsigned);
private:
	unsigned index;
	vector<vector<string>> local_store;
protected:
	vector<vector<string>> perm_store;

};

