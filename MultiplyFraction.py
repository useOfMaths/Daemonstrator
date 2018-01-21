# A class
class TimesFraction:

    # Simulate a constructor
    def __init__(self, fractions):
        self.numerators   = fractions['numerators']
        self.denominators = fractions['denominators']

        self.trial_factor = 0
        self.n_index = 0
        self.d_index = 0
        self.answer = [1, 1]

        # set trial_factor to the highest value amongst
        #both numerators and denominators
        for numerator in self.numerators:
            if numerator > self.trial_factor:
                self.trial_factor = numerator
        for denominator in self.denominators:
            if denominator > self.trial_factor:
                self.trial_factor = denominator

    # Returns a dictionary of the new numerator and denominator
    def doMultiply(self):
		# STEP 3:
        # We are counting down to test for mutual factors 
        while self.trial_factor > 1:
			# STEP 1:
            # iterate through numerators and check for factors
            while self.n_index < len(self.numerators):
                self.mutual_factor = False
                if self.numerators[self.n_index] % self.trial_factor == 0: # do we have a factor
                    # iterate through denominators and check for factors
                    while self.d_index < len(self.denominators):
                        if self.denominators[self.d_index] % self.trial_factor == 0: # is this factor mutual?
                            self.mutual_factor = True
                            break # stop as soon as we find a mutual factor so preserve the corresponding index

                        self.d_index += 1

                    break # stop as soon as we find a mutual factor so as to preserve the corresponding index

                self.n_index += 1

			# STEP 2:
            # where we have a mutual factor
            if self.mutual_factor:
                self.numerators[self.n_index]   /= self.trial_factor
                self.denominators[self.d_index] /= self.trial_factor
                continue # continue with next iteration repeating the current value of trial_factor

            self.n_index = 0
            self.d_index = 0
            self.trial_factor -= 1


        for numerator in self.numerators:
            self.answer[0] *= numerator
        for denominator in self.denominators:
            self.answer[1] *= denominator
            
        return {'numerator':int(self.answer[0]), 'denominator':int(self.answer[1])}
