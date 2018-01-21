package SUBTRACTFRACTION;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(doSubtract);
}

use warnings;
use strict;
use parent "ADDFRACTION";

my $answer;
my (@numerators, @denominators, @new_numerators);
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
	
	$answer = 0;
}

# returns an array --
# new numerator and new denominator(LCM) in that order
sub doSubtract {
	# STEPS 1, 2:
	my $call = ADDFRACTION->new(\%fractions);
	my @help = $call->canonizeFraction();
    @new_numerators = @{$help[0]};

	# STEP 3:
	# subtract all transformed numerators
	$answer = $new_numerators[0];
	$answer -= $new_numerators[$_] for 1 .. $#new_numerators;
	
	return ($answer, $help[1]);
}


1;

