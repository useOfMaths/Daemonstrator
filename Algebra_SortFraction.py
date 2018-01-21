#!/usr/bin/python
from SortFraction import ArrangeFraction

##
 # Sorting fractions
 ##
numerators = [1, 3, 5, 9]
denominators = [2, 4, 2, 10]
fractions = {'numerators':numerators, 'denominators':denominators}

print("\n    Sorting in ascending order the fractions:\n")
# Print as fraction
for numerator in fractions['numerators']: print('{:12d}'.format(numerator), end='')
print('{}{:>11}'.format('\n', ' '), end='')
for wasted in range(len(numerators)-1): print('{}'.format('-   ,       '), end='')
print('{:>1}'.format('-'))
for denominator in fractions['denominators']: print('{:12d}'.format(denominator), end='') 
print('\n\n')

# use the SortFraction class
sort_fract = ArrangeFraction(fractions)
fractions = sort_fract.sortAscending()

# Print as fraction
for numerator in fractions['numerators']: print('{:13d}'.format(numerator), end='')
print('{}{:>1}'.format('\nAnswer  =  ', ' '), end='')
for wasted in range(len(numerators)-1): print('{}'.format('-   ,        '), end='')
print('{:>1}'.format('-'))
for denominator in fractions['denominators']: print('{:13d}'.format(denominator), end='') 
print('\n\n')


print('\n\n')
