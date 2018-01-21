#!/usr/bin/python
from LowestTerm import LowTerm

##
 # Reduce fractions to Lowest Term
 #
fraction = {'numerator':16, 'denominator':640}

print('\n    To reduce to lowest term, simplifying:\n')
# Print as fraction
print('{:45d}'.format(fraction['numerator']))
print('{:>45}'.format('-'))
print('{:45d}'.format(fraction['denominator']))

# use the LowestTerm class
low_term = LowTerm(fraction)
fraction = low_term.reduceFraction()

print('{:46d}'.format(fraction['numerator']))
print('{:>46}'.format('Answer =    -'))
print('{:46d}'.format(fraction['denominator']))


print('\n\n')
