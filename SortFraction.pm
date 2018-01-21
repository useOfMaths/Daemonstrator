package SORTFRACTION;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(sortAscending sortDescending);
}

use warnings;
use strict;
use parent "ADDFRACTION";

my $answer;
my (@numerators, @denominators, @new_numerators);
my (@final_numerators, @final_denominators);
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
# reference to sorted numerators
# and denominators in that order
sub sortAscending {
	# STEPS 1, 2:
	my $call = ADDFRACTION->new(\%fractions);
	my @help = $call->canonizeFraction();
    @new_numerators = @{$help[0]};

	my @copy_numerators = @new_numerators;

	# STEP 3:
	# the little difference lies here
	@copy_numerators = sort {$a <=> $b} @copy_numerators;

	# map sorted (transformed) fractions to the original ones
	for my $sorted (@copy_numerators) {
		# get index using array value
		my ($index) = grep { $new_numerators[$_] eq $sorted } 0 .. $#new_numerators;
		push @final_numerators, $numerators[$index];
		push @final_denominators, $denominators[$index];
	}
	
	return (\@final_numerators, \@final_denominators);
}

sub sortDescending {
	# STEPS 1, 2:
	my $call = ADDFRACTION->new(\%fractions);
	my @help = $call->canonizeFraction();
    @new_numerators = @{$help[0]};

	my @copy_numerators = @new_numerators;

	# STEP 3:
	# the little difference lies here
	@copy_numerators = sort {$b <=> $a} @copy_numerators;

	# map sorted (transformed) fractions to the original ones
	for my $sorted (@copy_numerators) {
		# get index using array value
		my ($index) = grep { $new_numerators[$_] eq $sorted } 0 .. $#new_numerators;
		push @final_numerators, $numerators[$index];
		push @final_denominators, $denominators[$index];
	}
	
	return (\@final_numerators, \@final_denominators);
}


1;

