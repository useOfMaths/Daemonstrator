#!/usr/bin/perl;

use strict;
use warnings;

use COMBINATION;

my @subjects = ("Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda");
my $r = 3;

# Use the combination module/class
my $combo = COMBINATION->new();

# $result receives an array reference of references
my $result = $combo->possibleWordCombinations(\@subjects, $r);

print ("[", join(", ", @subjects), "] combination ", $r, ":\n\n");
# for each array reference in a dereferenced '$result'
print (join(", ", @{$_}), "\n") for @{$result};
print ("\n\nNumber of ways is ", scalar @{$result}, ".");

print "\n\n";