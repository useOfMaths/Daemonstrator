#pragma once

#include <string>
#include <vector>

using namespace std;

class Combination
{
public:
	Combination();
	virtual ~Combination();
	// variables
	vector<string> words;
	unsigned short r; // min length of word
	// functions
	vector<vector<string>> possibleWordCombinations(vector<string>, unsigned short);
	void progressiveCombination(void);
protected:
	vector<vector<string>> comb_store;
private:
	void repetitivePairing(vector<string>, unsigned);
	unsigned int i;
};

