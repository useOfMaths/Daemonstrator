#!/usr/bin/perl;
use strict;
use warnings;
use PRIMENUMBERS;

# Useful variables
my ($lower_boundary, $upper_boundary, $answer);

# Use the prime numbers module/class
$lower_boundary = 3;
$upper_boundary = 7;
my $prime_list = PRIMENUMBERS->new($lower_boundary, $upper_boundary);
$answer = $prime_list->getPrimes();
print "Prime numbers between $lower_boundary and $upper_boundary are:\n@{$answer}\n";


print "\n\n";