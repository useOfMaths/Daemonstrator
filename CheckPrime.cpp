#include "stdafx.h"
#include "CheckPrime.h"


CheckPrime::CheckPrime(unsigned val) {
	result = "";
	prime_suspect = val;
	square_root = sqrt(prime_suspect); // Get square root
	test_range = (int)ceil(square_root); // Extract an absolute value
}

/**
* Does the actual evaluation to see if our number is prime.
* @param - Takes no parameters
* @return - String (Resolve to check.)
*/
string CheckPrime::verifyPrime() {
	aux.str(""); // Clear int to string object
	aux << prime_suspect;
	// prime_suspect is a prime number until proven otherwise
	result = "Prime State:\n" + aux.str() + " is a prime number.";
	/* Loop through searching for factors. */
	for (unsigned i = 2; i < prime_suspect; i++) {
		if ((prime_suspect % i) == 0) {
			result = "Prime State:\n";
			result += aux.str() + " is not a prime number.\n";
			result += "At least one factor of " + aux.str();
			aux.str("");
			aux << i;
			result += " is " + aux.str();
			break;
		}
	}
	// If no factor is found:
	return result;
}

CheckPrime::~CheckPrime() {
}
