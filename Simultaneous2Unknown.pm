package SIMULTANEOUS2UNKNOWN;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(solveSimultaneous);
}

use warnings;
use strict;
use Carp "croak";

my ($x_variable, $y_variable);
my (@x_coefficients, @y_coefficients, @equals);
my @eliminator;
my %equations;

# simulate an object construct
# takes one argument  -- besides its package name;
# hash reference to array references for the variables
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
	
    $equations{x}	= $aux->{x};
    $equations{y}	= $aux->{y};
    $equations{eq}	= $aux->{eq};
	@x_coefficients	= @{$equations{x}};
	@y_coefficients	= @{$equations{y}};
	@equals			= @{$equations{eq}};
}

# Returns an array of the result
sub solveSimultaneous {
	# this is actually an array of references
	# not a multi-dimensional array
	# STEP 2:
    $eliminator[0][0] = $y_coefficients[1] * $x_coefficients[0];
    $eliminator[0][1] = $y_coefficients[1] * $equals[0];
	# STEP 3:
    $eliminator[1][0] = $y_coefficients[0] * $x_coefficients[1];
    $eliminator[1][1] = $y_coefficients[0] * $equals[1];

    eval {
		# STEPS 4, 5:
        $x_variable = ($eliminator[0][1] - $eliminator[1][1]) / ($eliminator[0][0] - $eliminator[1][0]);
		# STEP 6:
        $y_variable = ($equals[0] - $x_coefficients[0] * $x_variable) / $y_coefficients[0];
		
		return [$x_variable, $y_variable];
    } or croak "Error $@ happened";
}


1;

