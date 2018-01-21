package ADDFRACTION;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(doAdd canonizeFraction);
}

use warnings;
use strict;

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


# transforms fractions so they all have same denominator
# takes two references --
# to your numerators and denominators in that order
#
# returns an array --
# reference to new numerators and
# new denominator(LCM) in that order
sub canonizeFraction {
	my @new_nums;
	# STEP 1:
	# find their LCM
	use LCM;
    my $lcm = LCM->new(\@denominators);
    $lcm = $lcm->getLCM();

	# STEP 2:
	# transform fractions so they all have same denominator
    for (0 .. $#denominators) {
        push @new_nums, ($lcm / $denominators[$_] * $numerators[$_]);
    }
	return (\@new_nums, $lcm);
}

# returns an array --
# new numerator and new denominator(LCM) in that order
sub doAdd {
	my @help = canonizeFraction();
    @new_numerators = @{$help[0]};

	# STEP 3:
	# add all transformed numerators
    $answer += $new_numerators[$_] for 0 .. $#new_numerators;
	return ($answer, $help[1]);
}


1;

