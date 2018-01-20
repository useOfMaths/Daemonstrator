package LISTFACTORS;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(findFactors);
}

use warnings;
use strict;
use POSIX qw(ceil);

my ($find_my_factors, $sqrt_range);
my @found_factors;

# simulate an object construct
# takes two arguments  -- besides its name;
# start and stop values for the range
sub new {
	my $this = shift;
	my $parameters = {@_};
	bless $parameters, $this;
	$this->_init(@_);
	return $this;
}

# Simulate a constructor
sub _init {
	my $self = shift;
    $find_my_factors = shift;
	@found_factors = (1, $find_my_factors);
    $sqrt_range = ceil(sqrt($find_my_factors));
}

# Returns an array reference of the desired factors
sub findFactors() {
    # Loop through 1 to 'find_my_factors' and test for divisibility.
    for (2 .. $sqrt_range) {
        if (($find_my_factors % $_) == 0) {
            push @found_factors, $_;
            # Get the complementing factor by dividing 'find_my_factor' by variable i.
            push(@found_factors, ($find_my_factors / $_));
        }
    }

    # Sort the array in ascending order; Not entirely necessary.
    @found_factors = sort {$a <=> $b} @found_factors;

    return \@found_factors;
}

1;

