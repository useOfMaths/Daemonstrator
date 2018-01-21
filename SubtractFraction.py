from AddFraction import PlusFraction

# A class with a parent
class MinusFraction(PlusFraction):

    # A constructor
    def __init__(self, fractions):
        super().__init__(fractions)


    # Returns a dictionary of the new fraction
    def doSubtract(self):
		# STEPS 1, 2:
        self.canonizeFraction()

		# STEP 3:
		# subtract all transformed numerators
        self.answer = self.new_numerators[0]
        for count in range(1, len(self.new_numerators)): self.answer -= self.new_numerators[count]

        return {'numerator':self.answer, 'denominator':self.lcm}

