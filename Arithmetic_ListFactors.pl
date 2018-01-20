#!/usr/bin/perl;
use strict;
use warnings;
use LISTFACTORS;

# Useful variables
my ($test_guy, $answer);

# Use the list factors module/class
$test_guy = 48;
my $factor_list = LISTFACTORS->new($test_guy);
$answer = $factor_list->findFactors();
print ("Factors of $test_guy include:\n", join(", ", @{$answer}), "\n");


print "\n\n";