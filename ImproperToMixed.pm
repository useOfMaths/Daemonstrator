package IMPROPERTOMIXED;

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
# takes two arguments  -- besides its name;
# numerator and denominator values
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
    ($numerator, $denominator) = @_;
}

# Returns a hash reference of the new whole number and numerator
sub doConvert {
	my $new_numerator;
    my $whole_number;
	# STEP 1:
    for (reverse 2 .. $numerator - 1) {
        if (($_ % $denominator) == 0) {
			# STEP 2:
            $new_numerator = $numerator - $_;
			# STEP 3:
            $whole_number = $_ / $denominator;
            last;
        }
    }
	return {numerator => $new_numerator, whole_number => $whole_number};
}


1;

