# A class
class Sim2Unknown:

    # A constructor
    def __init__(self, equations):
        self.x_coefficients	= equations['x']
        self.y_coefficients	= equations['y']
        self.equals             = equations['eq']

        self.eliminator = [[[], []], [[], []]]

        
    # Returns a list of the result
    def solveSimultaneous(self):
        # eliminate y
		# STEP 2:
        self.eliminator[0][0] = self.y_coefficients[1] * self.x_coefficients[0]
        self.eliminator[0][1] = self.y_coefficients[1] * self.equals[0]
		# STEP 3:
        self.eliminator[1][0] = self.y_coefficients[0] * self.x_coefficients[1]
        self.eliminator[1][1] = self.y_coefficients[0] * self.equals[1]

        try:
			# STEPS 4, 5:
            self.x_variable = (self.eliminator[0][1] - self.eliminator[1][1]) / (self.eliminator[0][0] - self.eliminator[1][0])
			# STEP 6:
            self.y_variable = (self.equals[0] - self.x_coefficients[0] * self.x_variable) / self.y_coefficients[0]

            return [self.x_variable, self.y_variable]

        except:
            raise ValueError(None)
