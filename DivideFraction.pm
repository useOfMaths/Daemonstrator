package DIVIDEFRACTION;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(doDivide);
}

use warnings;
use strict;
use parent "MULTIPLYFRACTION"; 

my (@numerators, @denominators);
my %fractions;

# simulate an object construct
# takes one argument  -- besides its package name;
# hash reference to array references for numerators and denominators
sub new {
	no warnings "all";
	
	my $this = shift;
	my $parameters = shift; #this is already a hash reference
	bless $parameters, $this;
	$this->_init($parameters);
	return $this;
}

# Simulate a constructor
sub _init {
	my $self = shift;
	my $aux = shift;
	
    $fractions{numerators}		= $aux->{numerators};
    $fractions{denominators}	= $aux->{denominators};
	@numerators		= @{$fractions{numerators}};
	@denominators	= @{$fractions{denominators}};
}

# Returns a scalar of the new numerator
sub doDivide {
    my $temp;
    # Invert every other fraction but the first
    for (1 .. $#numerators) {
        $temp = $numerators[$_];
        $numerators[$_] = $denominators[$_];
        $denominators[$_] = $temp;
    }
	%fractions = (
		numerators	 => \@numerators,
		denominators => \@denominators
	);
	my $call = MULTIPLYFRACTION->new(\%fractions);
    return $call->doMultiply();
}


1;

