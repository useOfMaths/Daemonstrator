# Sure enough this is a module

# define a class
class EvenNumerals:
    
    ###
     # Our constructor.
     # @param alpha - for the start value
     # @param omega - for the end value
     ##
    def __init__(self, alpha, omega):
        self.start = alpha
        self.stop = omega
        self.result = [] # list to hold our answers

    # Returns an list of the desired set of even numbers
    def prepResult(self):
        # Loop from start to stop and rip out even numbers;
        self.i = 0
        while self.start <= self.stop:
            if self.start % 2 == 0: # modulo(%) is explained later
                self.result.append(self.start)
                self.i += 1
                
            self.start = self.start + 1 # increase start by 1
            
        return self.result

