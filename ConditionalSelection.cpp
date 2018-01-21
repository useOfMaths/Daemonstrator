#include "stdafx.h"
#include "ConditionalSelection.h"
#include <iostream>

ConditionalSelection::ConditionalSelection() : Selection()
{
}

vector<vector<string>> ConditionalSelection::limitedSelection(vector<string> candidates, unsigned short dimension, unsigned short minimum[], unsigned short maximum[]) {
	final_elements = {};
	groupSelection(candidates, dimension);
	for (int i = 0; i < complete_group.size(); i++) {
		bool state = false;
		for (int j = 0; j < words.size(); j++) {
			// get 'words[j]' frequency/count in group
			int frequency = count(complete_group[i].begin(), complete_group[i].end(), words[j]);
			if (frequency >= minimum[j] && frequency <= maximum[j]) {
				state = true;
			}
			else {
				state = false;
				break;
			}
		}
		// skip if already in net
		if (state) {
			final_elements.push_back(complete_group[i]);
		}
	}
	return final_elements;
}

ConditionalSelection::~ConditionalSelection()
{
}
