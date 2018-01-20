#!/usr/bin/perl;
use strict;
use warnings;
use ODDNUMBERS;

# Useful variables
my ($lower_boundary, $upper_boundary, $answer);

# Use the odd number module/class
$lower_boundary = 1;
$upper_boundary = 100;
my $odd_list = ODDNUMBERS->new($lower_boundary, $upper_boundary);
$answer = $odd_list->prepResult();
print "Odd numbers between $lower_boundary and $upper_boundary are:\n@{$answer}\n";


print "\n\n";