#!/usr/bin/perl;
use strict;
use warnings;
use MIXEDTOIMPROPER;
use IMPROPERTOMIXED;
use LOWESTTERM;
use MULTIPLYFRACTION;
use DIVIDEFRACTION;
use ADDFRACTION "doAdd";
use SUBTRACTFRACTION;
use SORTFRACTION;
use SIMULTANEOUS2UNKNOWN;
use SIMULTANEOUS3UNKNOWN;

# Useful variables
my ($numerator, $denominator, $whole_number, $solution);
my (@numerators, @denominators, @solutions);
my (%fraction, %fractions);

my (@x_coefficients, @y_coefficients, @z_coefficients);
my (@operators, @equals);

##
 # Convert fractions from Mixed to Improper
 ##
$whole_number = 3;
$numerator	  = 1;
$denominator  = 3;

print "    Converting from Mixed to Improper the fraction:\n";
# Print as fraction
printf("%55u\n", $numerator);
printf("%54u%s\n", $whole_number, "-");
printf("%55u\n", $denominator);

# use the MixedToImproper class
my $mix2imp = MIXEDTOIMPROPER->new($whole_number, $numerator, $denominator);
$numerator = $mix2imp->doConvert();

print "\n";

printf("%52u\n", $numerator);
printf("%52s\n", "Answer =      -");
printf("%52u\n", $denominator);


print "\n\n";


##
 # Convert fractions from Improper to Mixed
 ##
$numerator	 = 10;
$denominator = 3;

print "\n    Converting from Improper to Mixed the fraction:\n";
# Print as fraction
printf("%55u\n", $numerator);
printf("%55s\n", "-");
printf("%55u\n", $denominator);

# use the ImproperToMixed class
my $imp2mix = IMPROPERTOMIXED->new($numerator, $denominator);
%fraction = %{$imp2mix->doConvert()};

printf("\n%52u\n", $fraction{numerator});
printf("%50s%u%s\n", "Answer =   ", $fraction{whole_number}, "-");
printf("%52u\n", $denominator);


print "\n\n";


##
 # Reduce fractions to Lowest Term
 #
$numerator	 = 16;
$denominator = 640;

print "\n    To reduce to lowest term, simplifying:\n";
# Print as fraction
printf("%45u\n", $numerator);
printf("%45s\n", "-");
printf("%45u\n", $denominator);

# use the LowestTerm class
my $low_term = LOWESTTERM->new($numerator, $denominator);
%fraction = %{$low_term->reduceFraction()};

printf("\n%46u\n", $fraction{numerator});
printf("%46s\n", "Answer =    -");
printf("%46u\n", $fraction{denominator});


print "\n\n";


##
 # Multiplying fractions
 ##
@numerators	  = (16, 20, 27, 20);
@denominators = (9, 9, 640, 7);
%fractions = (
	numerators	 => \@numerators,
	denominators => \@denominators
);

print "\n    Solving:\n";
# Print as fraction
printf("%13u", $_) for @numerators;
printf("\n%12s", " ");
print "-     X      " for 1 .. $#numerators;
printf("%1s", "-");
print "\n";
printf("%13u", $_) for @denominators;
print "\n";

# use the MultiplyFraction class
my $mul_fract = MULTIPLYFRACTION->new(\%fractions);
%fraction = %{$mul_fract->doMultiply()};

printf("\n%25u\n", $fraction{numerator});
printf("%25s\n", "Answer =      -");
printf("%25u\n", $fraction{denominator});


print "\n\n";


##
 # Dividing fractions
 ##
@numerators	  = (16, 9, 640, 7);
@denominators = (9, 20, 27, 20);
%fractions = (
	numerators	 => \@numerators,
	denominators => \@denominators
);

print "\n    Solving:\n";
# Print as fraction
printf("%13u", $_) for @numerators;
printf("\n%11s", " ");
print "-      /     " for 1 .. $#numerators;
printf("%2s\n", "-");
printf("%13u", $_) for @denominators;
print "\n";

# use the DivideFraction class
my $div_fract = DIVIDEFRACTION->new(\%fractions);
%fraction = %{$div_fract->doDivide()};

printf("\n%25u\n", $fraction{numerator});
printf("%25s\n", "Answer =         -");
printf("%25u\n", $fraction{denominator});


print "\n\n";


##
 # Adding fractions
 ##
@numerators = (1, 1, 1, 1);
@denominators = (4, 4, 4, 4);
%fractions = (
	numerators	 => \@numerators,
	denominators => \@denominators
);

print "\n    Solving:\n";
# Print as fraction
printf("%13u", $_) for @numerators;
printf("\n%12s", " ");
print "-     +      " for 1 .. $#numerators;
printf("%2s\n", "-");
printf("%13u", $_) for @denominators;
print "\n";

# use the AddFraction class
my $add_fract = ADDFRACTION->new(\%fractions);
@solutions = $add_fract->doAdd();

printf("\n%25u\n", $solutions[0]);
printf("%25s\n", "Answer =     -");
printf("%25u\n", $solutions[1]);


print "\n\n";


##
 # Subtracting fractions
 ##
@numerators = (9, 3, 5, 7);
@denominators = (2, 4, 12, 18);
%fractions = (
	numerators	 => \@numerators,
	denominators => \@denominators
);

print "\n    Solving:\n";
# Print as fraction
printf("%13u", $_) for @numerators;
printf("\n%12s", " ");
print "-     -      " for 1 .. $#numerators;
printf("%2s\n", "-");
printf("%13u", $_) for @denominators;
print "\n";

# use the SubtractFraction class
my $sub_fract = SUBTRACTFRACTION->new(\%fractions);
@solutions = $sub_fract->doSubtract();

printf("\n%25u\n", $solutions[0]);
printf("%25s\n", "Answer =     -");
printf("%25u\n", $solutions[1]);


print "\n\n";


##
 # Sorting fractions
 ##
@numerators = (1, 3, 5, 9);
@denominators = (2, 4, 2, 10);

print "\n    Sorting in ascending order the fractions:\n";
# Print as fraction
printf("%35s", " ");
printf("%9u", $_) for @numerators;
printf("\n%43s", " ");
print "- ,      " for 1 .. $#numerators;
printf("%2s", "-");
printf("\n%35s", " ");
printf("%9d", $_) for @denominators;
print "\n";

# use the SortFraction class
my $sort_fract = SORTFRACTION->new(\%fractions);
@solutions = $sort_fract->sortAscending();

@numerators = @{$solutions[0]};
@denominators = @{$solutions[1]};
%fractions = (
	numerators	 => \@numerators,
	denominators => \@denominators
);

# Print as fraction
printf("\n%35s", " ");
printf("%9u", $_) for @numerators;
printf("\n%43s", "Answer =    ");
print "- ,      " for 1 .. $#numerators;
printf("%2s", "-");
printf("\n%35s", " ");
printf("%9u", $_) for @denominators;


print "\n\n";


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