# A class
class PlusFraction:

    # Simulate a constructor
    def __init__(self, fractions):
        
        self.numerators   = fractions['numerators']
        self.denominators = fractions['denominators']

        self.answer = 0
        self.new_numerators = []


    # transforms fractions so they all have same denominator
    # takes a dictionary of a list of numerators and denominators
    #
    # returns a dictionary of the new numerators and new denominator(LCM)
    def canonizeFraction(self):
		# STEP 1:
        from LCM import findLCM
        self.l_c_m = findLCM(self.denominators)
        self.lcm = self.l_c_m.getLCM()

		# STEP 2:
        # make numerators vary(ratio) with lcm
        for count in range(len(self.denominators)):
            self.new_numerators.append(int(self.lcm / self.denominators[count] * self.numerators[count]))

        return None

    # returns a dictionary of the
    # new numerator and new denominator(LCM)
    def doAdd(self):
        self.canonizeFraction()
        
		# STEP 3:
		# add all transformed numerators
        for num in self.new_numerators: self.answer += num
        return {'numerator':self.answer, 'denominator':self.lcm}

