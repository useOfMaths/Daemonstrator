#!/usr/bin/perl;
use strict;
use warnings;
use ADDFRACTION "doAdd";

# Useful variables
my (@numerators, @denominators, @solutions);
my %fractions;

##
 # Adding fractions
 ##
@numerators = (1, 1, 1, 1);
@denominators = (4, 4, 4, 4);
%fractions = (
	numerators	 => \@numerators,
	denominators => \@denominators
);

print "\n    Solving:\n";
# Print as fraction
printf("%13u", $_) for @numerators;
printf("\n%12s", " ");
print "-     +      " for 1 .. $#numerators;
printf("%2s\n", "-");
printf("%13u", $_) for @denominators;
print "\n";

# use the AddFraction class
my $add_fract = ADDFRACTION->new(\%fractions);
@solutions = $add_fract->doAdd();

printf("\n%25u\n", $solutions[0]);
printf("%25s\n", "Answer =     -");
printf("%25u\n", $solutions[1]);


print "\n\n";