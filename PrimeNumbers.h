#pragma once

#include <iostream>
#include <vector>
#include <string>
#include <sstream>
#include <math.h>

using namespace std;

class PrimeNumbers {
public:
	PrimeNumbers(unsigned, unsigned);
	virtual ~PrimeNumbers();
	string getPrimes();
private:
	vector<unsigned> list_of_primes; // We will house our gathered prime numbers here.
	unsigned int start; // Where to start.
	unsigned int stop; // Where to stop.
	unsigned int progress; // progress report
	unsigned int index; // index into array list_of_primes
	double square_root; // Our loop range for speed enhancement
	bool do_next_iteration;
	string result;
	stringstream aux;

};

