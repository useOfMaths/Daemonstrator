from math import ceil, sqrt

# A class
class Factors:
    # Simulate a constructor
    def __init__(self, candidate):
        self.find_my_factors = candidate
        self.found_factors = [1, self.find_my_factors] # 1 and itself are automatic factors
        self.sqrt_range = ceil(sqrt(self.find_my_factors))

    # Returns an array reference of the desired factors
    def findFactors(self):
        # Loop through 1 to 'find_my_factors' and test for divisibility.
        for self.count in range(2, self.sqrt_range):
            if self.find_my_factors % self.count == 0:
                self.found_factors.append(self.count)
                # Get the complementing factor by dividing 'find_my_factor' by variable count.
                self.found_factors.append(int(self.find_my_factors / self.count))

        # Sort the array in ascending order Not entirely necessary.
        self.found_factors.sort()

        return self.found_factors

