#!/usr/bin/perl;
use strict;
use warnings;
use MULTIPLYFRACTION;

# Useful variables
my (@numerators, @denominators);
my (%fraction, %fractions);

##
 # Multiplying fractions
 ##
@numerators	  = (16, 20, 27, 20);
@denominators = (9, 9, 640, 7);
%fractions = (
	numerators	 => \@numerators,
	denominators => \@denominators
);

print "\n    Solving:\n";
# Print as fraction
printf("%13u", $_) for @numerators;
printf("\n%12s", " ");
print "-     X      " for 1 .. $#numerators;
printf("%1s", "-");
print "\n";
printf("%13u", $_) for @denominators;
print "\n";

# use the MultiplyFraction class
my $mul_fract = MULTIPLYFRACTION->new(\%fractions);
%fraction = %{$mul_fract->doMultiply()};

printf("\n%25u\n", $fraction{numerator});
printf("%25s\n", "Answer =      -");
printf("%25u\n", $fraction{denominator});


print "\n\n";