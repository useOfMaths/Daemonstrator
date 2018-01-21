#pragma once

#include "Selection.h"
#include <array>

class ConditionalSelection : public Selection
{
public:
	ConditionalSelection();
	virtual ~ConditionalSelection();
	vector<vector<string>> limitedSelection(vector<string>, unsigned short, unsigned short[], unsigned short[]);
private:
	vector<vector<string>> final_elements;
};

