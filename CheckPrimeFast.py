# Import the necessary math functions
from math import ceil, sqrt

# A class
class TestPrimenessFast:

    # Constructor
    def __init__(self, suspect):
        self.prime_suspect = suspect

    # returns true if prime_suspect is a prime false otherwise.
    def verifyPrimeFast(self):
        # prime_suspect is a prime number until proven otherwise
        # Loop through searching for factors.
        self.test_range = ceil(sqrt(self.prime_suspect))
        for self.count in range(2, self.test_range):
            if self.prime_suspect % self.count == 0:
                self.a_factor = self.count
                return False

        # If no factor is found:
        return True
