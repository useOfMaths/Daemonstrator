#include "stdafx.h"
#include "Selection.h"


Selection::Selection()
{
}

vector<vector<string>> Selection::groupSelection(vector<string> candidates, unsigned short dimension) {
	words = candidates;
	r = dimension;
	complete_group = {};
	i = 0;
	recursiveFillUp({});

	return complete_group;
}

// pick elements recursively
void Selection::recursiveFillUp(vector<string> temp) {
	vector<string> * picked_elements;
	picked_elements = new vector<string>[words.size()];
	unsigned j = i;
	while (j < words.size()) {
		picked_elements[j] = temp;
		picked_elements[j].push_back(words[j]);
		// recoil factor
		if (i >= words.size()) {
			i = j;
		}
		// satisfied yet?
		if (picked_elements[j].size() == r) {
			complete_group.push_back(picked_elements[j]);
		}
		else if (picked_elements[j].size() < r) {
			recursiveFillUp(picked_elements[j]);
		}
		j++;
	}
	if (!picked_elements[--j].empty() && picked_elements[j].size() == r) {
		i++; // keep recoil factor straightened out
	}
	delete[] picked_elements;
}

Selection::~Selection()
{
}
