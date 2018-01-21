#!/usr/bin/python
from MixedToImproper import Mixed2Improper

##
 # Convert fractions from Mixed to Improper
 ##
fraction = {'whole_number':3, 'numerator':1, 'denominator':3}

print("    Converting from Mixed to Improper the fraction:\n")
# Print as fraction
print(   '{:55d}'.format(fraction['numerator']))
print('{:53d} {}'.format(fraction['whole_number'], '-'))
print(   '{:55d}'.format(fraction['denominator']))

# use the MixedToImproper class
mix2imp = Mixed2Improper(fraction)
fraction['numerator'] = mix2imp.doConvert()

print("\n")

print('{:52d}'.format(fraction['numerator']))
print('{:>52}'.format('Answer =      -'))
print('{:52d}'.format(fraction['denominator']))


print("\n\n")
