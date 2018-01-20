#!/usr/bin/perl;
use strict;
use warnings;
use LISTPRIMEFACTORS;

# Useful variables
my ($test_guy, $answer);

# Use the list prime factors module/class
$test_guy = 97;
my $prime_factors = LISTPRIMEFACTORS->new($test_guy);
$answer = $prime_factors->onlyPrimeFactors();
print ("Prime factorising $test_guy gives:\n", join(" X ", @{$answer}), "\n");


print "\n\n";