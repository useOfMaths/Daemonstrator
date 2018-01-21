#!/usr/bin/python
from AddFraction import PlusFraction


##
 # Adding fractions
 ##
numerators = [1, 1, 1, 1]
denominators = [4, 4, 4, 4]
fractions = {'numerators':numerators, 'denominators':denominators}

print('\n    Solving:\n')
# Print as fraction
for numerator in fractions['numerators']: print('{:13d}'.format(numerator), end='')
print('{}{:>12}'.format('\n', ' '), end='')
for wasted in range(len(numerators)-1): print('{}'.format('-     +      '), end='')
print('{:>1}'.format('-'))
for denominator in fractions['denominators']: print('{:13d}'.format(denominator), end='') 
print('\n\n')

# use the AddFraction class
add_fract = PlusFraction(fractions)
fraction = add_fract.doAdd()

print('{:25d}'.format(fraction['numerator']))
print('{:>25}'.format('Answer   =   -'))
print('{:25d}'.format(fraction['denominator']))


print('\n\n')
