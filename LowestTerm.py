# A class
class LowTerm:

    # A constructor
    def __init__(self, fraction):
        self.numerator   = fraction['numerator']
        self.denominator = fraction['denominator']

        # set trial_factor to the smaller value between numerator and denominator
        if self.numerator < self.denominator: self.trial_factor = self.numerator
        else: self.trial_factor = self.denominator

    # Returns a dictionary of the new numerator and denominator
    def reduceFraction(self):
        # We are counting down to test for mutual factors 
        while self.trial_factor > 1:
            # do we have a factor
            if self.numerator % self.trial_factor == 0:
                # is this factor mutual?
                if self.denominator % self.trial_factor == 0:
                    # where we have a mutual factor
                    self.numerator   /= self.trial_factor
                    self.denominator /= self.trial_factor
                    continue

            self.trial_factor -= 1

        return {'numerator':int(self.numerator), 'denominator':int(self.denominator)}

