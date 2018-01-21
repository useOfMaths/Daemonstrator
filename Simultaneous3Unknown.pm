package SIMULTANEOUS3UNKNOWN;

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

my ($x_variable, $y_variable, $z_variable, $partial_solution);
my (@x_coefficients, @y_coefficients, @z_coefficients, @equals);
my @eliminator;
my %equations;

# simulate an object construct
# takes one argument  -- besides its package name;
# hash reference to array references of the variables
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
	$equations{z}	= $aux->{z};
    $equations{eq}	= $aux->{eq};
	@x_coefficients	= @{$equations{x}};
	@y_coefficients	= @{$equations{y}};
	@z_coefficients	= @{$equations{z}};
	@equals			= @{$equations{eq}};
}

# Returns an array of the result
sub solveSimultaneous {
	use LCM;
    my $lcm = LCM->new(\@z_coefficients);
    $lcm = $lcm->getLCM();

	# STEP 1:
    $eliminator[0][0] = ($lcm * $x_coefficients[0]) / $z_coefficients[0];
    $eliminator[0][1] = ($lcm * $y_coefficients[0]) / $z_coefficients[0];
    $eliminator[0][2] = ($lcm * $equals[0])			/ $z_coefficients[0];

    $eliminator[1][0] = ($lcm * $x_coefficients[1]) / $z_coefficients[1];
    $eliminator[1][1] = ($lcm * $y_coefficients[1]) / $z_coefficients[1];
    $eliminator[1][2] = ($lcm * $equals[1])			/ $z_coefficients[1];

    $eliminator[2][0] = ($lcm * $x_coefficients[2]) / $z_coefficients[2];
    $eliminator[2][1] = ($lcm * $y_coefficients[2]) / $z_coefficients[2];
    $eliminator[2][2] = ($lcm * $equals[2])			/ $z_coefficients[2];

	# STEP 2:
    my @new_x = (
        $eliminator[0][0] - $eliminator[1][0],
        $eliminator[1][0] - $eliminator[2][0]
    );
    my @new_y = (
        $eliminator[0][1] - $eliminator[1][1],
        $eliminator[1][1] - $eliminator[2][1]
    );
    my @new_eq = (
        $eliminator[0][2] - $eliminator[1][2],
        $eliminator[1][2] - $eliminator[2][2]
    );

    eval {
		# STEP 3
		use SIMULTANEOUS2UNKNOWN;
        my $s2u = SIMULTANEOUS2UNKNOWN->new({x=>\@new_x, y=>\@new_y, eq=>\@new_eq});
		$partial_solution = $s2u->solveSimultaneous();

        $x_variable = $partial_solution->[0];
        $y_variable = $partial_solution->[1];
		# STEP 4:
        $z_variable = ($equals[0] - $x_coefficients[0] * $x_variable - 
			$y_coefficients[0] * $y_variable) / $z_coefficients[0];
			
		return [$x_variable, $y_variable, $z_variable];
    } or croak "Error $@ happenned!";
}


1;

