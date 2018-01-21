#!/usr/bin/python
from ImproperToMixed import Improper2Mixed

##
 # Convert fractions from Improper to Mixed
 ##
fraction = {'numerator':10, 'denominator':3}

print("\n    Converting from Improper to Mixed the fraction:\n")
# Print as fraction
print('{:55d}'.format(fraction['numerator']))
print('{:>55}'.format('-'))
print('{:55d}'.format(fraction['denominator']))

# use the ImproperToMixed class
imp2mix = Improper2Mixed(fraction)
fraction = imp2mix.doConvert()

print(      '{:52d}'.format(fraction['numerator']))
print('{:>48} {} {}'.format('Answer =   ', fraction['whole_number'], '-'))
print(      '{:52d}'.format(fraction['denominator']))


print("\n\n")
