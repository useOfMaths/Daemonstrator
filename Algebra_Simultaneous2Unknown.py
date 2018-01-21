#!/usr/bin/python
from Simultaneous2Unknown import Sim2Unknown

##
 # Simultaneous Equations with 2 unknowns
 ##
operators = ['+', '+']
x_coefficients = [2, 1]
y_coefficients = [-1, 1]
equals = [1, 2]

equations = {'x':x_coefficients, 'y':y_coefficients, 'eq':equals}

if y_coefficients[0] < 0: operators[0] = '-'
if y_coefficients[1] < 0: operators[1] = '-'

print('\n    Solving simultaneously the equations:\n')
#Print as an equation
print('{:40d}{}  {}  {:d}{} {:d}'.format(x_coefficients[0], 'x', operators[0], abs(y_coefficients[0]), 'y  = ', equals[0]))
print('{:40d}{}  {}  {:d}{} {:d}'.format(x_coefficients[1], 'x', operators[1], abs(y_coefficients[1]), 'y  = ', equals[1]))
print('{}{:>30} {}{:>40}'.format('\n', 'Yields:', '\n', '(x, y)  =  '), end='')

try:
    sim2unk = Sim2Unknown(equations)
    solution = sim2unk.solveSimultaneous()

    print('{}{:.4f}{} {:.4f}{}'.format('(', solution[0], ',', solution[1], ')'))

except: print('{}'.format('(infinity,  infinity)'))


print('\n\n')
