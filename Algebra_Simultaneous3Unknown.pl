#!/usr/bin/perl;
use strict;
use warnings;
use SIMULTANEOUS3UNKNOWN;

# Useful variables
my $solution;

my (@x_coefficients, @y_coefficients, @z_coefficients);
my (@operators, @equals);

##
 # Simultaneous Equations with 3 unknowns
 ##

@x_coefficients = (2, 4, 2);
@y_coefficients = (1, -1, 3);
@z_coefficients = (1, -2, -8);
@equals			= (4, 1, -3);

@operators = ();
for (0 .. 2) {
	$operators[$_][0] = '+';
	$operators[$_][0] = '-' if $y_coefficients[$_] < 0;
	$operators[$_][1] = '+';
	$operators[$_][1] = '-' if $z_coefficients[$_] < 0;
}

print "\n    Solving simultaneously the equations:\n";
#Print as an equation
printf(
	"%40dx %s %dy %s %dz = %d\n", $x_coefficients[0], $operators[0][0],
	abs($y_coefficients[0]), $operators[0][1], abs($z_coefficients[0]), $equals[0]
);
printf(
	"%40dx %s %dy %s %dz = %d\n", $x_coefficients[1], $operators[1][0],
	abs($y_coefficients[1]), $operators[1][1], abs($z_coefficients[1]), $equals[1]
);
printf(
	"%40dx %s %dy %s %dz = %d\n", $x_coefficients[2], $operators[2][0],
	abs($y_coefficients[2]), $operators[2][1], abs($z_coefficients[2]), $equals[2]
);
printf("\n%30s\n%40s", "Yields:", "(x, y, z)  =  ");

eval {
	my $sim3unk = SIMULTANEOUS3UNKNOWN->new({
		x	=> \@x_coefficients,
		y	=> \@y_coefficients,
		z	=> \@z_coefficients,
		eq	=> \@equals
	});
	$solution = $sim3unk->solveSimultaneous();

	printf("(%.4f, %.4f, %.4f)\n", $solution->[0], $solution->[1], $solution->[2]);

} or printf("(%s, %s, %s)\n", "infinity", "infinity", "infinity");


print "n\n";