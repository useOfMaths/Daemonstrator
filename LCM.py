# A class
class findLCM:
    # A constructor
    def __init__(self, group):
        self.set_of_numbers = []
        for member in group:
            self.set_of_numbers.append(member)
        # Sort array in descending order
        self.set_of_numbers.sort(reverse=True)

        self.all_factors = []

        self.index = 1
        self.state_check = False
        self.calc_result = 1
        

    def findLCMFactors(self):
        #  Copy 'set_of_numbers' into 'arg_copy'
        self.arg_copy = []
        for number in self.set_of_numbers:
            self.arg_copy.append(number)
		# STEP 1:
        # sort in descending order
        self.arg_copy.sort(reverse=True)

        while self.index <= self.arg_copy[0]:
            self.state_check = False
            for count in range(len(self.set_of_numbers)):
                if self.set_of_numbers[count] % self.index == 0:
					# STEP 3:
                    self.set_of_numbers[count] /= self.index
                    if self.state_check == False:
                        self.all_factors.append(self.index)

                    self.state_check = True # do not store the factor twice

			# STEP 4:
            if self.state_check: return self.findLCMFactors()
            
            self.index += 1

        return None
    

    # Returns an array reference of the desired set of even numbers
    def getLCM(self):
		# STEP 2:
        self.index = 2
        self.findLCMFactors()

        # iterate through and retrieve members
        for factor in self.all_factors:
            self.calc_result *= factor

        return self.calc_result
    
