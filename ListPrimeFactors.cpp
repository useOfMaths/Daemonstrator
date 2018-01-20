#include "stdafx.h"
#include "ListPrimeFactors.h"


ListPrimeFactors::ListPrimeFactors(unsigned val) {
	found_prime_factors = {};
	find_my_factors = val;
	aux << val;
	render_factors = "The prime factors of " + aux.str() + " are: \n";
	i = 2;
}

int ListPrimeFactors::onlyPrimeFactors(int in_question) {
	int temp_limit;
	temp_limit = (int)ceil(sqrt(in_question));

	while (i <= temp_limit) {
		if (i != 1 && (in_question % i) == 0) { // avoid an infinite loop with the i != 1 check.
			found_prime_factors.push_back(i);
			return onlyPrimeFactors(in_question / i);
		}
		i++;
	}
	found_prime_factors.push_back(in_question);

	return 0;
}

/**
* Renders the prime prime factors to screen.
*/
string ListPrimeFactors::getPrimeFactors() {
	onlyPrimeFactors(find_my_factors);
	found_prime_factors.shrink_to_fit();

	//iterate through and retrieve members
	for (unsigned factor : found_prime_factors) {
		aux.str("");
		aux << factor;
		render_factors += aux.str() + " X ";
	}
	render_factors = render_factors.substr(0, render_factors.length() - 3);

	return render_factors;
}


ListPrimeFactors::~ListPrimeFactors() {
}
