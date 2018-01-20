#include "stdafx.h"
#include "CheckPrimeFast.h"


CheckPrimeFast::CheckPrimeFast(unsigned val)
{
	result = "";
	prime_suspect = val;
	square_root = sqrt(prime_suspect); // Get square root
	test_range = (int)ceil(square_root); // Extract an absolute value
}


/**
* Fast copy.
* @param - Takes no parameters
* @return - String (Resolve to check.)
*/
string CheckPrimeFast::verifyPrimeFast() {
	aux.str("");
	aux << prime_suspect;
	result = "Prime State:\n" + aux.str() + " is a prime number.";
	/* Loop through a small range searching for factors. */
	for (int i = 2; i < test_range; i++) {
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


CheckPrimeFast::~CheckPrimeFast()
{
}
