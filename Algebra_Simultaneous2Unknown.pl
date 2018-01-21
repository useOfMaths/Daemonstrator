#!/usr/bin/perl;
use strict;
use warnings;
use SIMULTANEOUS2UNKNOWN;

# Useful variables
my $solution;
my (@x_coefficients, @y_coefficients);
my (@operators, @equals);

##
 # Simultaneous Equations with 2 unknowns
 ##
@operators = ('+', '+');
@x_coefficients = (2, 1);
@y_coefficients = (-1, 1);
@equals = (1, 2);

$operators[0] = '-' if $y_coefficients[0] < 0;
$operators[1] = '-' if $y_coefficients[1] < 0;

print "\n    Solving simultaneously the equations:\n";
#Print as an equation
printf("%40dx %s %dy = %d\n", $x_coefficients[0], $operators[0], abs($y_coefficients[0]), $equals[0]);
printf("%40dx %s %dy = %d\n", $x_coefficients[1], $operators[1], abs($y_coefficients[1]), $equals[1]);
printf("\n%30s\n%40s", "Yields:", "(x, y)  =  ");

eval {
	my $sim2unk = SIMULTANEOUS2UNKNOWN->new({
		x	=> \@x_coefficients,
		y	=> \@y_coefficients,
		eq	=> \@equals
	});
	$solution = $sim2unk->solveSimultaneous();

	printf("(%.4f, %.4f)\n", $solution->[0], $solution->[1]);

} or printf("(%s, %s)\n", "infinity", "infinity");


print "\n\n";