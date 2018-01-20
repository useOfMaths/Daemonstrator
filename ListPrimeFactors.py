from math import ceil, sqrt

# A class
class PrimeFactors:
    def __init__(self, val):
        self.find_my_factors = val
        self.found_prime_factors = []

    # takes one argument, the candidate for factorisation
    # returns an array reference of the prime factors
    def onlyPrimeFactors(self):
        self.temp_limit = ceil(sqrt(self.find_my_factors))

		# STEP 1:
        self.i = 2
        while self.i <= self.temp_limit:
			# STEP 4:
            # avoid an infinite loop with the i != 1 check.
            if self.i != 1 and self.find_my_factors % self.i == 0:
                self.found_prime_factors.append(self.i)
				# STEP 2:
                self.find_my_factors = int(self.find_my_factors / self.i)
				# STEP 3:
                return self.onlyPrimeFactors()

            self.i += 1

        self.found_prime_factors.append(self.find_my_factors)
        return self.found_prime_factors

 
