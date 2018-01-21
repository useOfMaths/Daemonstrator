package LOWESTTERM;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(reduceFraction);
}

use warnings;
use strict;

my ($numerator, $denominator, $trial_factor);

# simulate an object construct
# takes three arguments  -- besides its name;
# whole_number, numerator and denominator values
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
    ($numerator, $denominator) = @_;

    $trial_factor = $numerator < $denominator ? $numerator : $denominator;
}

# Returns a hash reference of the new numerator and denominator
sub reduceFraction {
    # We are counting down to test for mutual factors 
    while ($trial_factor > 1) {
        # do we have a factor
        if (($numerator % $trial_factor) == 0) {
            # is this factor mutual?
            if (($denominator % $trial_factor) == 0) {
                # where we have a mutual factor
                $numerator /= $trial_factor;
                $denominator /= $trial_factor;
                next;
            }
        }
        $trial_factor--;
    }
	return {numerator => $numerator, denominator => $denominator};
}


1;

