#pragma once

#include <string>
#include <vector>

using namespace std;

class Selection
{
public:
	Selection();
	virtual ~Selection();
	// variables
	vector<string> words;
	unsigned short r; // min length of word
	// functions
	vector<vector<string>> groupSelection(vector<string>, unsigned short);
	void recursiveFillUp(vector<string>);
protected:
	vector<vector<string>> complete_group;
private:
	unsigned i;
};

