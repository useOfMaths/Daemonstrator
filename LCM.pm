package LCM;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(getLCM);
}

use warnings;
use strict;

my ($index, $state_check, $calc_result);
my (@set_of_numbers, @arg_copy, @all_factors);

# simulate an object construct
# takes one arguments  -- besides its name;
# array reference of values whose LCM is sought
sub new {
	my $this = shift;
	
	no warnings "all";
	my $parameters = {@_};
	bless $parameters, $this;
	$this->_init(@_);
	return $this;
}

# Simulate a constructor
sub _init {
	my $self = shift;
	
	my $tmp = shift;
    @set_of_numbers = @{$tmp};
	@all_factors = ();
    # Sort array in descending order
	@set_of_numbers = sort {$b <=> $a} @set_of_numbers;

    $index = 2;
    $state_check = 0;
    $calc_result = 1;
}

sub findLCMFactors {
    #  Copy 'set_of_numbers' into 'arg_copy'
    @arg_copy = @set_of_numbers;
    # sort in descending order
    @arg_copy = sort {$b <=> $a} @arg_copy;

    while ($index <= $arg_copy[0]) {
        $state_check = 0;
        for (0 .. $#set_of_numbers) {
            if (($set_of_numbers[$_] % $index) == 0) {
                $set_of_numbers[$_] /= $index;
                push @all_factors, $index if !$state_check;
                $state_check = 1;
            }
        }
        return findLCMFactors() if $state_check;
        $index++;
    }
    return;
}

# Returns an array reference of the desired set of even numbers
sub getLCM {
    $index = 2;
    findLCMFactors();

    # iterate through and retrieve members
    for (@all_factors) {
        $calc_result *= $_;
    }

    return $calc_result;
}


1;

