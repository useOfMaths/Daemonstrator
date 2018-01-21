#!/usr/bin/perl;

use strict;
use warnings;

use CONDITIONALSELECTION;

my @subjects = ("0", "1", "2", "3", "4", "5", "6", "7", "8", "9");
my @min_occurrence = (0, 0, 1, 0, 0, 1, 0, 0, 1, 0);
my @max_occurrence = (4, 3, 2, 4, 3, 2, 4, 3, 2, 4);
my $r = 9;

# Use the conditionalselection module/class
my $choose = CONDITIONALSELECTION->new();

# $result receives an array reference of references
my $result = $choose->limitedSelection(\@subjects, $r, \@min_occurrence, \@max_occurrence);

print ("[", join(", ", @subjects), "] conditioned selection ", $r, ":\n\n");
# for each array reference in a dereferenced '$result'
print (join(", ", @{$_}), "\n") for @{$result};
print ("\n\nNumber of ways is ", scalar @{$result}, ".");

print "\n\n";