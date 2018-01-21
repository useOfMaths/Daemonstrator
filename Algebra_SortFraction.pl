#!/usr/bin/perl;
use strict;
use warnings;
use SORTFRACTION;

# Useful variables
my (@numerators, @denominators, @solutions);
my %fractions;

##
 # Sorting fractions
 ##
@numerators = (1, 3, 5, 9);
@denominators = (2, 4, 2, 10);
%fractions = (
	numerators	 => \@numerators,
	denominators => \@denominators
);

print "\n    Sorting in ascending order the fractions:\n";
# Print as fraction
printf("%35s", " ");
printf("%9u", $_) for @numerators;
printf("\n%43s", " ");
print "- ,      " for 1 .. $#numerators;
printf("%2s", "-");
printf("\n%35s", " ");
printf("%9d", $_) for @denominators;
print "\n";

# use the SortFraction class
my $sort_fract = SORTFRACTION->new(\%fractions);
@solutions = $sort_fract->sortAscending();

@numerators = @{$solutions[0]};
@denominators = @{$solutions[1]};

# Print as fraction
printf("\n%35s", " ");
printf("%9u", $_) for @numerators;
printf("\n%43s", "Answer =    ");
print "- ,      " for 1 .. $#numerators;
printf("%2s", "-");
printf("\n%35s", " ");
printf("%9u", $_) for @denominators;


print "\n\n";