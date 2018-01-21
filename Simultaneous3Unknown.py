# A class
class Sim3Unknown:

    # A constructor
    def __init__(self, equations):
        self.x_coefficients	= equations['x']
        self.y_coefficients	= equations['y']
        self.z_coefficients	= equations['z']
        self.equals             = equations['eq']

        self.eliminator = [[[], [], []], [[], [], []], [[], [], []]]


    # Returns a list of the result
    def solveSimultaneous(self):
        from LCM import findLCM
        self.l_c_m = findLCM(self.z_coefficients)
        self.lcm = self.l_c_m.getLCM()

		# STEP 1:
        # eliminate z variable
        self.eliminator[0][0] = (self.lcm * self.x_coefficients[0]) / self.z_coefficients[0]
        self.eliminator[0][1] = (self.lcm * self.y_coefficients[0]) / self.z_coefficients[0]
        self.eliminator[0][2] = (self.lcm * self.equals[0])         / self.z_coefficients[0]

        self.eliminator[1][0] = (self.lcm * self.x_coefficients[1]) / self.z_coefficients[1]
        self.eliminator[1][1] = (self.lcm * self.y_coefficients[1]) / self.z_coefficients[1]
        self.eliminator[1][2] = (self.lcm * self.equals[1])         / self.z_coefficients[1]

        self.eliminator[2][0] = (self.lcm * self.x_coefficients[2]) / self.z_coefficients[2]
        self.eliminator[2][1] = (self.lcm * self.y_coefficients[2]) / self.z_coefficients[2]
        self.eliminator[2][2] = (self.lcm * self.equals[2])         / self.z_coefficients[2]

		# STEP 2:
        self.new_x  = [self.eliminator[0][0] - self.eliminator[1][0], self.eliminator[1][0] - self.eliminator[2][0]]
        self.new_y  = [self.eliminator[0][1] - self.eliminator[1][1], self.eliminator[1][1] - self.eliminator[2][1]]
        self.new_eq = [self.eliminator[0][2] - self.eliminator[1][2], self.eliminator[1][2] - self.eliminator[2][2]]

        try:
			# STEP 3
            from Simultaneous2Unknown import Sim2Unknown
            self.s2u = Sim2Unknown({'x':self.new_x, 'y':self.new_y, 'eq':self.new_eq})
            self.partial_solution = self.s2u.solveSimultaneous()

            self.x_variable = self.partial_solution[0]
            self.y_variable = self.partial_solution[1]
			# STEP 4:
            self.z_variable = (self.equals[0] - self.x_coefficients[0] * self.x_variable - self.y_coefficients[0] * self.y_variable) / self.z_coefficients[0]

            return [self.x_variable, self.y_variable, self.z_variable]

        except:
            raise ValueError(None)
