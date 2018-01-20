package FASTHCF;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(getHCF);
}

use warnings;
use strict;
use Carp qw(croak);

my ($index, $all_round_factor, $calc_result);
my (@set_of_numbers, @arg_copy, @common_factors, @minimal_prime_factors);

# simulate an object construct
# takes one argument  -- besides its package name;
# reference to set whose HCF is to found
sub new {
	no warnings;
	
	my $this = shift;
	my $parameters = {@_};
	bless $parameters, $this;
	$this->_init(@_);
	return $this;
}

# Simulate a constructor
sub _init {
	my $self = shift;
	
	my $tmp = shift;
    @common_factors = ();
	@set_of_numbers = @{$tmp};
	# STEP 1:
	@set_of_numbers = sort {$a <=> $b} @set_of_numbers;

    @arg_copy = @set_of_numbers;

    $index = 2;
    $all_round_factor = 0; # state flag
    $calc_result = 1;
}

# STEP 2:
# does the grunt work
# takes no arguments but requires '@set_of_numbers' to be set
sub findHCFFactors {
    while ($index < scalar @minimal_prime_factors) {
        $all_round_factor = 1;
		# STEP 3:
        for (0 .. $#set_of_numbers) {
            $all_round_factor = 0 if !($all_round_factor &&
                    $arg_copy[$_] % $minimal_prime_factors[$index] == 0);
        }
		# STEP 4:
        if ($all_round_factor) {
            $arg_copy[$_] /= $minimal_prime_factors[$index] for 0 .. $#set_of_numbers;
            push @common_factors, $minimal_prime_factors[$index];
        }
        $index++;
    }
    return;
}

# Returns a scalar value of the HCF
sub getHCF {
	require LISTPRIMEFACTORS or croak "Error $! occurred.";
	my $aux = LISTPRIMEFACTORS->new($set_of_numbers[0]);
	@minimal_prime_factors = @{$aux->onlyPrimeFactors()};

    $index = 0;
    findHCFFactors();

    #iterate through and retrieve members
    for (@common_factors) {
        $calc_result *= $_;
    }

    return $calc_result;
}


1;

