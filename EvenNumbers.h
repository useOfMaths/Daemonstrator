#pragma once

#include <iostream>
#include <string>
#include <sstream>

using namespace std;

class EvenNumbers {
public:
	EvenNumbers(unsigned, unsigned);
	virtual ~EvenNumbers();
	string prepResult();
private:
	unsigned int start; // Our starting point
	unsigned int stop; // where we will stop
	string result; // Store result here.
	stringstream aux; // helps us convert int to string
};

