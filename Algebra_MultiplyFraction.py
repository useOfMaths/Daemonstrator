#!/usr/bin/python
from MultiplyFraction import TimesFraction

##
 # Multiplying fractions
 ##
numerators   = [16, 20, 27, 20]
denominators = [9, 9, 640, 7]
fractions = {'numerators':numerators, 'denominators':denominators}

print('\n    Solving:\n')
# Print as fraction
for numerator in fractions['numerators']: print('{:13d}'.format(numerator), end='')
print('{}{:>12}'.format('\n', ' '), end='')
for wasted in range(len(numerators)-1): print('{}'.format('-     X      '), end='')
print('{:>1}'.format('-'))
for denominator in fractions['denominators']: print('{:13d}'.format(denominator), end='') 
print('\n\n')

# use the MultiplyFraction class
mul_fract = TimesFraction(fractions)
fraction = mul_fract.doMultiply()

print('{:25d}'.format(fraction['numerator']))
print('{:>25}'.format('Answer   =   -'))
print('{:25d}'.format(fraction['denominator']))


print('\n\n')
