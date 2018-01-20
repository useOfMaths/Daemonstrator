#include "stdafx.h"
#include "EvenNumbers.h"

/**
* Our constructor.
* @param first - for the start value
* @param last - for the end value
*/
EvenNumbers::EvenNumbers(unsigned first, unsigned last) {
	start = first;
	stop = last;
	aux << first;
	result = "Even numbers between " + aux.str();
	aux.str(""); // clear 'aux'
	aux << last;
	result += " and " + aux.str() + " are: \n";
	aux.str("");
}

/**
* nitty gritty
* @return - list of the required even numbers.
*/
string EvenNumbers::prepResult() {
	/*
	* Loop from start to stop and rip out odd numbers;
	*/
	while (start <= stop) {
		if ((start % 2) == 0) { // modulo(%) is explained below
			aux << start;
			result = result + aux.str() + "; ";
			aux.str("");
		}
		start = start + 1; // increase start by 1
	}
	return result;
}

EvenNumbers::~EvenNumbers() {
}
