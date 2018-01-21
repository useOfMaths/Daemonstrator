# No doubt this is a module

# A class
class Mixed2Improper:
    
# A constructor
    def __init__(self, fraction):
        self.whole_number = fraction['whole_number']
        self.numerator    = fraction['numerator']
        self.denominator  = fraction['denominator']
        

    # Returns a scalar of the new numerator
    def doConvert(self):
		# STEPS 1, 2:
        return self.whole_number * self.denominator + self.numerator


