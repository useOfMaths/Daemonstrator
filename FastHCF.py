# A class
class quickHCF:

    # A constructor
    def __init__(self, group):
        self.set_of_numbers = []
        self.arg_copy = []
        for val in group:
            self.set_of_numbers.append(val)
            self.arg_copy.append(val)
		# STEP 1:
        self.set_of_numbers.sort()
        self.arg_copy.sort()
        
        self.common_factors = []

        self.index = 2
        self.all_round_factor = False # state flag
        self.calc_result = 1


	# STEP 2:
    # does the grunt work
    # takes no arguments but requires 'set_of_numbers' to be set
    def findHCFFactors(self):
        while self.index < len(self.minimal_prime_factors):
            self.all_round_factor = True
			# STEP 3:
            for count in range(len(self.set_of_numbers)):
                if self.all_round_factor and self.arg_copy[count] % self.minimal_prime_factors[self.index] != 0:
                    self.all_round_factor = False

			# STEP 4:
            if self.all_round_factor:
                for count_off in range(len(self.set_of_numbers)):
                    self.arg_copy[count_off] /= self.minimal_prime_factors[self.index]

                self.common_factors.append(self.minimal_prime_factors[self.index])

            self.index += 1
        return None

    # Returns a scalar value of the HCF
    def getHCF(self):
        # use only direct factors of the smallest member
        from ListPrimeFactors import PrimeFactors
        self.aux = PrimeFactors(self.set_of_numbers[0])
        self.minimal_prime_factors = self.aux.onlyPrimeFactors()

        # go ahead and see which of the above factors are mutual
        self.index = 0
        self.findHCFFactors()

        #iterate through and retrieve members
        for factor in self.common_factors:
            self.calc_result *= factor

        return self.calc_result
