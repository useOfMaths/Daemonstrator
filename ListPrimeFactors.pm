package LISTPRIMEFACTORS;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(onlyPrimeFactors);
}

use warnings;
use strict;
use POSIX qw(ceil);

my ($find_my_factors, $i);
my @found_prime_factors;

# simulate an object construct
# takes one argument  -- besides its name;
# value whose prime factors is to be found
sub new {
	no warnings;
	my $this = shift;
	my $parameters = {@_};
	bless $parameters, $this;
	$this->_init(@_);
	return $this;
}

# simulate a constructor
sub _init {
	my $self = shift;
	
    $find_my_factors = shift;
    @found_prime_factors = ();
	# STEP 1:
    $i = 2;
}

# takes one argument, the candidate for factorisation;
# returns an array reference of the prime factors
sub onlyPrimeFactors {
	my $in_question = $find_my_factors;
	$in_question = shift unless $_[0] eq __PACKAGE__;
    my $temp_limit;
    $temp_limit = ceil(sqrt($in_question));

    while ($i <= $temp_limit) {
		# STEP 4:
		# avoid an infinite loop with the i != 1 check.
        if ($i != 1 && ($in_question % $i) == 0) {
            push @found_prime_factors, $i;
			# STEPS 2, 3:
            return onlyPrimeFactors($in_question / $i);
        }
        $i++;
    }
    push @found_prime_factors, $in_question;

    return \@found_prime_factors;;
}


1;

 