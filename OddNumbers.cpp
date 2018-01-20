#include "stdafx.h"
#include "OddNumbers.h"

/**
* Our constructor.
* @param first - for the start value
* @param last - for the end value
*/
OddNumbers::OddNumbers(unsigned first, unsigned last) {
	start = first;
	stop = last;
	aux << first;
	result = "Odd numbers between " + aux.str();
	aux.str(""); // clear 'aux'
	aux << last;
	result += " and " + aux.str() + " are: \n";
	aux.str("");
}

/**
* nitty gritty
* @return - list of the required even numbers.
*/
string OddNumbers::prepResult() {
	/*
	* Loop from start to stop and rip out odd numbers;
	*/
	while (start <= stop) {
		if ((start % 2) != 0) { // modulo(%) is explained below
			aux << start;
			result += aux.str() + "; "; // Mind the '+' in front of the '='
			aux.str("");
		}
		start++; // increase start by 1(same as start = start + 1
	}
	return result;
}

OddNumbers::~OddNumbers() {
}
