#!/usr/bin/perl;
use strict;
use warnings;
use EVENNUMBERS;

# Useful variables
my ($lower_boundary, $upper_boundary, $answer);

# Use the even number module/class
$lower_boundary = 1;
$upper_boundary = 100;
my $even_list = EVENNUMBERS->new($lower_boundary, $upper_boundary);
$answer = $even_list->prepResult();
print "Even numbers between $lower_boundary and $upper_boundary are:\n@{$answer}\n";


print "\n\n";