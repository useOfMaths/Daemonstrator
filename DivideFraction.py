from MultiplyFraction import TimesFraction

# A class with a parent
class DivFraction(TimesFraction):

    # A constructor
    def __init__(self, fractions):
        super().__init__(fractions)


    # Returns a dictionary of the new fraction
    def doDivide(self):
        # Invert every other fraction but the first
        for count in range(1, len(self.numerators)):
            self.temp = self.numerators[count]
            self.numerators[count] = self.denominators[count]
            self.denominators[count] = self.temp


        return self.doMultiply()
