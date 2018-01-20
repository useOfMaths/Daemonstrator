#include "stdafx.h"
#include "PrimeNumbers.h"


PrimeNumbers::PrimeNumbers(unsigned first, unsigned last) {
	start = first;
	stop = last;
	// STEP 1:
	progress = 9;

	list_of_primes = { 2, 3, 5, 7 };

	square_root = 0;
}

/**
* Garners the prime numbers between the requested range.
* @param - Nil
*/
string PrimeNumbers::getPrimes() {
	// STEP 2:
	for (; progress < stop; progress += 2) {
		
		do_next_iteration = false; // a flag

		// STEPS 3, 4:
		// Check through already accumulated prime numbers
		// to see if any is a factor of "progress".
		square_root = (int)ceil(sqrt(progress));

		index = 0;
		for (; list_of_primes[index] <= square_root; index++) {
			if ((progress % list_of_primes[index]) == 0) {
				do_next_iteration = true;
				break;
			}
		}
		if (do_next_iteration) {
			continue;
		}

		// if all checks are scaled,then "progress" is our guy.
		list_of_primes.push_back(progress);
	}

	list_of_primes.shrink_to_fit(); // not altogether necessary

	// Display result.
	aux << start;
	result = "The set of prime numbers between " + aux.str() + " and ";
	aux.str("");
	aux << stop;
	result += aux.str() + " are: \n";

	for (unsigned n : list_of_primes) {
		aux.str("");
		aux << n;
		result += aux.str() + "; ";
	}
	return result;
}


PrimeNumbers::~PrimeNumbers() {
}
