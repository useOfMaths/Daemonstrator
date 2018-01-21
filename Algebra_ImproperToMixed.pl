#!/usr/bin/perl;
use strict;
use warnings;
use IMPROPERTOMIXED;

# Useful variables
my ($numerator, $denominator, $whole_number, $solution);
my %fraction;

##
 # Convert fractions from Improper to Mixed
 ##
$numerator	 = 10;
$denominator = 3;

print "\n    Converting from Improper to Mixed the fraction:\n";
# Print as fraction
printf("%55u\n", $numerator);
printf("%55s\n", "-");
printf("%55u\n", $denominator);

# use the ImproperToMixed class
my $imp2mix = IMPROPERTOMIXED->new($numerator, $denominator);
%fraction = %{$imp2mix->doConvert()};

printf("\n%52u\n", $fraction{numerator});
printf("%50s%u%s\n", "Answer =   ", $fraction{whole_number}, "-");
printf("%52u\n", $denominator);


print "\n\n";