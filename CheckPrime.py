# define a class
class TestPrimeness:

    def __init__(self, suspect):
        self.prime_suspect = suspect


    # returns true if $prime_suspect is a prime false otherwise.
    def verifyPrime(self):
        # prime_suspect is a prime number until proven otherwise
        # Loop through searching for factors.
        for self.count in range(2, self.prime_suspect):
            if self.prime_suspect % self.count == 0:
                self.a_factor = self.count
                return False

        # If no factor is found:
        return True
