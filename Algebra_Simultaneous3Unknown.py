#!/usr/bin/python
from Simultaneous3Unknown import Sim3Unknown

##
 # Simultaneous Equations with 3 unknowns
 ##

x_coefficients = [2, 4, 2]
y_coefficients = [1, -1, 3]
z_coefficients = [1, -2, -8]
equals         = [4, 1, -3]

operators = [[[], []], [[], []], [[], []]]
for i in range(3):
    operators[i][0] = '+'
    if y_coefficients[i] < 0: operators[i][0] = '-'
    operators[i][1] = '+'
    if z_coefficients[i] < 0: operators[i][1] = '-'

print('\n    Solving simultaneously the equations:\n')
#Print as an equation
print(\
    '{:40d}{}  {}  {:d}{}  {}  {:d}{}  {:d}'.format(x_coefficients[0], 'x', operators[0][0],\
    abs(y_coefficients[0]), 'y', operators[0][1], abs(z_coefficients[0]), 'z  =', equals[0])\
)
print(\
    '{:40d}{}  {}  {:d}{}  {}  {:d}{}  {:d}'.format(x_coefficients[1], 'x', operators[1][0],\
    abs(y_coefficients[1]), 'y', operators[1][1], abs(z_coefficients[1]), 'z  =', equals[1])\
)
print(\
    '{:40d}{}  {}  {:d}{}  {}  {:d}{}  {:d}'.format(x_coefficients[2], 'x', operators[2][0],\
    abs(y_coefficients[2]), 'y', operators[2][1], abs(z_coefficients[2]), 'z  =', equals[2])\
)
print('{}{:>30} {}{:>40}'.format('\n', 'Yields:', '\n', '(x, y, z)  =  '), end='')

try:
    sim3unk = Sim3Unknown({'x':x_coefficients, 'y':y_coefficients, 'z':z_coefficients, 'eq':equals})
    solution = sim3unk.solveSimultaneous()

    print('{}{:.4f}{} {:.4f}{} {:.4f}{}'.format('(', solution[0], ',', solution[1], ',', solution[2], ')'))

except: print('{}'.format('(infinity,  infinity, infinity)'))


print('n\n')
