#pragma once

#include <iostream>
#include <math.h>
#include <string.h>
#include <string>
#include <sstream>

using namespace std;

class CheckPrimeFast
{
public:
	CheckPrimeFast(unsigned);
	virtual ~CheckPrimeFast();
	string verifyPrimeFast(void);
private:
	unsigned int prime_suspect; // We suspect that this number is prime
	double square_root; // this variable is a helping one.
	unsigned int test_range; // range for minimal looping
	string result;
	stringstream aux;
};

