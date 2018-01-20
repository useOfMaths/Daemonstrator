from math import sqrt, ceil

# A class
class ListPrimes:

    # Constructor: takes two arguments  -- besides its name
    # alpha and omega values for the range
    def __init__(self, alpha, omega):
        self.start = alpha
        self.stop = omega + 1
        # STEP 1:
        self.progress = 9

        self.list_of_primes = [2, 3, 5, 7]
        self.square_root = 0


    # Returns an list of the desired set of prime numbers
    def getPrimes(self):

        # STEP 2:
        for self.progress in range(self.progress, self.stop, 2):

            self.do_next_iteration = False # a flag

            # STEPS 3, 4:
            # Check through already accumulated prime numbers
            # to see if any is a factor of "progress".
            self.square_root = int(ceil(sqrt(self.progress)))
            
            self.index = 0
            while self.list_of_primes[self.index] <= self.square_root:
                if self.progress % self.list_of_primes[self.index] == 0:
                    self.do_next_iteration = True
                    break

                self.index += 1

            if self.do_next_iteration == True:
                continue

            # if all checks are scaled,then "progress" is our guy.
            self.list_of_primes.append(self.progress)

        return self.list_of_primes
    
