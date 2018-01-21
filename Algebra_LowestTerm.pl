#!/usr/bin/perl;
use strict;
use warnings;
use LOWESTTERM;

# Useful variables
my ($numerator, $denominator, $whole_number, $solution);
my (@numerators, @denominators, @solutions);
my (%fraction, %fractions);

##
 # Reduce fractions to Lowest Term
 #
$numerator	 = 16;
$denominator = 640;

print "\n    To reduce to lowest term, simplifying:\n";
# Print as fraction
printf("%45u\n", $numerator);
printf("%45s\n", "-");
printf("%45u\n", $denominator);

# use the LowestTerm class
my $low_term = LOWESTTERM->new($numerator, $denominator);
%fraction = %{$low_term->reduceFraction()};

printf("\n%46u\n", $fraction{numerator});
printf("%46s\n", "Answer =    -");
printf("%46u\n", $fraction{denominator});


print "\n\n";