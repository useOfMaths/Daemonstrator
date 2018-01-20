#!/usr/bin/perl;
use strict;
use warnings;
use ODDNUMBERS;

# Useful variables
my ($lower_boundary, $upper_boundary, $answer);

# Collect Input
print "\n\nEnter the range for your odd numbers.\n";

print "Enter Start Number: ";
$lower_boundary = <>;
chomp $lower_boundary;

print "Enter Stop Number: ";
$upper_boundary = <>;
chomp $upper_boundary;

my $odd_list = ODDNUMBERS->new($lower_boundary, $upper_boundary);
$answer = $odd_list->prepResult();
print "Odd numbers between $lower_boundary and $upper_boundary are:\n@{$answer}\n";


print "\n\n";