#!/usr/bin/perl;
use strict;
use warnings;
use MIXEDTOIMPROPER;

# Useful variables
my ($numerator, $denominator, $whole_number, $solution);

##
 # Convert fractions from Mixed to Improper
 ##
$whole_number = 3;
$numerator	  = 1;
$denominator  = 3;

print "    Converting from Mixed to Improper the fraction:\n";
# Print as fraction
printf("%55u\n", $numerator);
printf("%54u%s\n", $whole_number, "-");
printf("%55u\n", $denominator);

# use the MixedToImproper class
my $mix2imp = MIXEDTOIMPROPER->new($whole_number, $numerator, $denominator);
$numerator = $mix2imp->doConvert();

print "\n";

printf("%52u\n", $numerator);
printf("%52s\n", "Answer =      -");
printf("%52u\n", $denominator);


print "\n\n";