#!/usr/bin/python
from DivideFraction import DivFraction

##
 # Dividing fractions
 ##
numerators   = [16, 9, 640, 7]
denominators = [9, 20, 27, 20]
fractions = {'numerators':numerators, 'denominators':denominators}

print('\n    Solving:\n')
# Print as fraction
for numerator in fractions['numerators']: print('{:13d}'.format(numerator), end='')
print('{}{:>12}'.format('\n', ' '), end='')
for wasted in range(len(numerators)-1): print('{}'.format('-     /      '), end='')
print('{:>1}'.format('-'))
for denominator in fractions['denominators']: print('{:13d}'.format(denominator), end='') 
print('\n\n')

# use the DivideFraction class
div_fract = DivFraction(fractions)
fraction = div_fract.doDivide()

print('{:25d}'.format(fraction['numerator']))
print('{:>25}'.format('Answer   =   -'))
print('{:25d}'.format(fraction['denominator']))


print('\n\n')
