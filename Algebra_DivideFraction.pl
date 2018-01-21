#!/usr/bin/perl;
use strict;
use warnings;
use DIVIDEFRACTION;

# Useful variables
my (@numerators, @denominators);
my (%fraction, %fractions);

##
 # Dividing fractions
 ##
@numerators	  = (16, 9, 640, 7);
@denominators = (9, 20, 27, 20);
%fractions = (
	numerators	 => \@numerators,
	denominators => \@denominators
);

print "\n    Solving:\n";
# Print as fraction
printf("%13u", $_) for @numerators;
printf("\n%11s", " ");
print "-      /     " for 1 .. $#numerators;
printf("%2s\n", "-");
printf("%13u", $_) for @denominators;
print "\n";

# use the DivideFraction class
my $div_fract = DIVIDEFRACTION->new(\%fractions);
%fraction = %{$div_fract->doDivide()};

printf("\n%25u\n", $fraction{numerator});
printf("%25s\n", "Answer =         -");
printf("%25u\n", $fraction{denominator});


print "\n\n";