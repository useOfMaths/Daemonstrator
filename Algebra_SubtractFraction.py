#!/usr/bin/python
from SubtractFraction import MinusFraction

##
 # Subtracting fractions
 ##
numerators   = [9, 3, 5, 7]
denominators = [2, 4, 12, 18]
fractions = {'numerators':numerators, 'denominators':denominators}

print('\n    Solving:\n')
# Print as fraction
for numerator in fractions['numerators']: print('{:13d}'.format(numerator), end='')
print('{}{:>12}'.format('\n', ' '), end='')
for wasted in range(len(numerators)-1): print('{}'.format('-     +      '), end='')
print('{:>1}'.format('-'))
for denominator in fractions['denominators']: print('{:13d}'.format(denominator), end='') 
print('\n\n')

# use the SubtractFraction class
sub_fract = MinusFraction(fractions)
fraction = sub_fract.doSubtract()

print('{:25d}'.format(fraction['numerator']))
print('{:>25}'.format('Answer   =   -'))
print('{:25d}'.format(fraction['denominator']))


print('\n\n')
