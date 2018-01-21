package MIXEDTOIMPROPER;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(doConvert);
}

use warnings;
use strict;

my ($whole_number, $numerator, $denominator);

# simulate an object construct
# takes three arguments  -- besides its name;
# whole_number, numerator and denominator values
sub new {
	no warnings "all";
	
	my $this = shift;
	my $parameters = {@_};
	bless $parameters, $this;
	$this->_init(@_);
	return $this;
}

# Simulate a constructor
sub _init {
	my $self = shift;
    ($whole_number, $numerator, $denominator) = @_;
}

# Returns a scalar of the new numerator
sub doConvert {
	# STEPS 1, 2:
    return ($whole_number * $denominator) + $numerator;
}


1;

