from AddFraction import PlusFraction

# A class with a parent
class ArrangeFraction(PlusFraction):

    # A constructor
    def __init__(self, fractions):
        super().__init__(fractions)

        self.final_numerators   = []
        self.final_denominators = []


    # Returns a dictionary of the new fraction
    def sortAscending(self):
		# STEPS 1, 2:
        self.canonizeFraction()

        self.copy_numerators = []
        for member in self.new_numerators: self.copy_numerators.append(member);

		# STEP 3:
        # the little difference lies here(sort ascending)
        self.copy_numerators.sort()

        # map sorted (transformed) fractions to the original ones
        for numerator in self.copy_numerators:
            # get index using list value
            self.position = self.new_numerators.index(numerator)
            self.final_numerators.append(self.numerators[self.position])
            self.final_denominators.append(self.denominators[self.position])
                    
        return {'numerators':self.final_numerators, 'denominators':self.final_denominators}

    # Returns a dictionary of the new fraction
    def sortDescending(self):
		# STEPS 1, 2:
        self.canonizeFraction()

        self.copy_numerators = []
        for member in self.new_numerators: self.copy_numerators.append(member);

		# STEP 3:
        # the little difference lies here(sort ascending)
        self.copy_numerators.sort(reverse=True)

        # map sorted (transformed) fractions to the original ones
        for numerator in self.copy_numerators:
            # get index using list value
            self.position = self.new_numerators.index(numerator)
            self.final_numerators.append(self.numerators[self.position])
            self.final_denominators.append(self.denominators[self.position])
                    
        return {'numerators':self.final_numerators, 'denominators':self.final_denominators}
