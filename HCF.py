# A class
class findHCF:
    # A constructor
    def __init__(self, group):
        self.set_of_numbers = [] # will hold the the values to be sent in
        # make copy of argument
        for value in group:
            self.set_of_numbers.append(value)
		# STEP 1:
        self.set_of_numbers.sort() # sort ascending
        
        self.common_factors = [] # for housing all common factors
        self.all_round_factor = False # boolean state flag

        self.calc_result = 1

    # does the grunt work
    # takes no arguments but requires '@set_of_numbers' to be set
    def findHCFFactors(self):
        # use the smallest in the set for the range
        while self.index < self.set_of_numbers[0]:
            self.index += 1
            # Check for factors common to every member of 'set_of_numbers'
            self.all_round_factor = True
			# STEP 2:
            for count in range(len(self.set_of_numbers)):
                if self.all_round_factor and self.set_of_numbers[count] % self.index != 0:
                    self.all_round_factor = False

			# STEP 3:
            # Divide every member of 'set_of_numbers by each common factor
            if self.all_round_factor:
                for count_off in range(len(self.set_of_numbers)):
                    self.set_of_numbers[count_off] /= self.index

                self.common_factors.append(self.index)
				# STEP 4:
                return self.findHCFFactors()

        return None

    # Returns a scalar value of the HCF
    def getHCF(self):
        self.index = 1
        self.findHCFFactors()

        #iterate through and retrieve members
        for factor in self.common_factors:
            self.calc_result *= factor

        return self.calc_result



