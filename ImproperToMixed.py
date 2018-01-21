# A class
class Improper2Mixed:

    # A constructor
    def __init__(self, fraction):
        self.numerator   = fraction['numerator']
        self.denominator = fraction['denominator']

    # Returns a dictionary of the new fraction
    def doConvert(self):
		# STEP 1:
        for dividend in range(self.numerator, 0, -1):
            if dividend % self.denominator == 0:
				# STEP 2:
                self.new_numerator = self.numerator - dividend
				# STEP 3:
                self.whole_number = int(dividend / self.denominator)
                break

        return {'whole_number':self.whole_number, 'numerator':self.new_numerator, 'denominator':self.denominator}

