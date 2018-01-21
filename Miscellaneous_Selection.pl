#!/usr/bin/perl;

use strict;
use warnings;

use SELECTION;

my @subjects = ("0", "1", "2", "3", "4", "5", "6", "7", "8", "9");
my $r = 9;

# Use the selection module/class
my $pick = SELECTION->new();

# $result receives an array reference of references
my $result = $pick->groupSelection(\@subjects, $r);

print ("[", join(", ", @subjects), "] selection ", $r, ":\n\n");
# for each array reference in a dereferenced '$result'
print (join(", ", @{$_}), "\n") for @{$result};
print ("\n\nNumber of ways is ", scalar @{$result}, ".");

print "\n\n";