# define a class
class OddNumerals:

    ###
     # Our constructor.
     # @param alpha - for the start value
     # @param omega - for the end value
     ##
    def __init__(self, alpha, omega):
        self.start = alpha
        self.stop = omega
        self.result = [] # list to hold our answers


    # Returns an list of the desired set of odd numbers
    def prepResult(self):
        # Loop from start to stop and rip out odd numbers;
        self.i = 0
        while self.start <= self.stop:
            if self.start % 2 != 0:
                self.result.append(self.start)
                self.i += 1
                
            self.start = self.start + 1 # increase start by 1
            
        return self.result
