package MULTIPLYFRACTION;

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

my ($trial_factor, $n_index, $d_index, $mutual_factor);
my (@numerators, @denominators, @answer);
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
	
    $trial_factor = 0;
    $n_index = 0;
    $d_index = 0;
    $answer[0] = 1;
    $answer[1] = 1;

    for (@numerators)	{ $trial_factor = $_ if $_ > $trial_factor; }
    for (@denominators) { $trial_factor = $_ if $_ > $trial_factor; }
}

# Returns a hash reference of the new numerator and denominator
sub doMultiply {
	# STEP 3:
    # We are counting down to test for mutual factors 
    while ($trial_factor > 1) {
		# STEP 1:
        # iterate through numerators and check for factors
        while ($n_index < scalar @numerators) {
            $mutual_factor = 0;
            if (($numerators[$n_index] % $trial_factor) == 0) { # do we have a factor
                # iterate through denominators and check for factors
                while ($d_index < scalar @denominators) {
                    if (($denominators[$d_index] % $trial_factor) == 0) { # is this factor mutual?
                        $mutual_factor = 1;
                        last; # stop as soon as we find a mutual factor so preserve the corresponding index
                    }
                    $d_index++;
                }
                last; # stop as soon as we find a mutual factor so as to preserve the corresponding index
            }
            $n_index++;
        }
		# STEP 2:
        # where we have a mutual factor
        if ($mutual_factor) {
            $numerators[$n_index] /= $trial_factor;
            $denominators[$d_index] /= $trial_factor;
            next; # continue with next iteration repeating the current value of trial_factor
        }
        $n_index = 0;
        $d_index = 0;
        $trial_factor--;
    }

    for (0 .. $#numerators) {
        $answer[0] *= $numerators[$_];
        $answer[1] *= $denominators[$_];
    }
	
	return {numerator => $answer[0], denominator => $answer[1]};
}


1;

