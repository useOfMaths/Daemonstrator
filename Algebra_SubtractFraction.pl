#!/usr/bin/perl;
use strict;
use warnings;
use SUBTRACTFRACTION;

# Useful variables
my (@numerators, @denominators, @solutions);
my %fractions;

##
 # Subtracting fractions
 ##
@numerators = (9, 3, 5, 7);
@denominators = (2, 4, 12, 18);
%fractions = (
	numerators	 => \@numerators,
	denominators => \@denominators
);

print "\n    Solving:\n";
# Print as fraction
printf("%13u", $_) for @numerators;
printf("\n%12s", " ");
print "-     -      " for 1 .. $#numerators;
printf("%2s\n", "-");
printf("%13u", $_) for @denominators;
print "\n";

# use the SubtractFraction class
my $sub_fract = SUBTRACTFRACTION->new(\%fractions);
@solutions = $sub_fract->doSubtract();

printf("\n%25u\n", $solutions[0]);
printf("%25s\n", "Answer =     -");
printf("%25u\n", $solutions[1]);


print "\n\n";