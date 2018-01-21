#!/usr/bin/perl;

use strict;
use warnings;

use PERMUTATION;

my @subjects = ("Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda");
my $r = 4;

# Use the permutation module/class
my $perm = PERMUTATION->new();

# $result receives an array reference of references
my $result = $perm->possibleWordPermutations(\@subjects, $r);

print ("[", join(", ", @subjects), "] permutation ", $r, ":\n\n");
# for each array reference in a dereferenced '$result'
print (join(", ", @{$_}), "\n") for @{$result};
print ("\n\nNumber of ways is ", scalar @{$result}, ".");

print "\n\n";