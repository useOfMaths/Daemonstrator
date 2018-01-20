package CHECKPRIME;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(verifyPrime);
}

use warnings;
use strict;
use POSIX qw(ceil);

my $prime_suspect;
our $a_factor;

# simulate an object construct
# takes one argument  -- besides its name;
# value for the test
sub new {
	no warnings;
	my $this = shift;
	my $parameters = {@_};
	bless $parameters, $this;
	$this->_init(@_);
	return $this;
}

# Simulate a constructor
sub _init {
	my $self = shift;
	$prime_suspect = shift;
}

# returns true if $prime_suspect is a prime; false otherwise.
sub verifyPrime {
    # prime_suspect is a prime number until proven otherwise
    # Loop through searching for factors.
    for (2 .. $prime_suspect) {
        if (($prime_suspect % $_) == 0) {
			$a_factor = $_;
            return 0;
        }
    }
    # If no factor is found:
    return 1;
}

1;