package PRIMENUMBERS;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(getPrimes);
}

use warnings;
use strict;
use POSIX qw(ceil pow); # round andlround seemed to be unavailable, so we go for 'ceil'

my ($start, $stop, $progress, $index, $square_root, $do_next_iteration);
my (@result, @list_of_primes);

# simulate an object construct
# takes two arguments  -- besides its name;
# start and stop values for the range
sub new {
	my $this = shift;
	my $parameters = {@_};
	bless $parameters, $this;
	$this->_init(@_);
	return $this;
}

# simulate a constructor
sub _init {
	my $self = shift;
	($start, $stop) = @_;
	# STEP 1:
    $progress = 9;

    @list_of_primes = (2, 3, 5, 7);

    $square_root = 0;
}

# Returns an array reference of the desired set of prime numbers
sub getPrimes {
	# STEP 2:
    for (; $progress <= $stop; $progress += 2) {
		
		$do_next_iteration = 0; # a flag

		# STEPS 3, 4:
        # Check through already accumulated prime numbers
        # to see if any is a factor of "progress".
		$square_root = ceil(sqrt($progress));

		$index = 0;
        for (; $list_of_primes[$index] <= $square_root; $index++) {
            if ($progress % $list_of_primes[$index] == 0) {
				$do_next_iteration = 1;
				last;
			}
        }
		next if $do_next_iteration;

        # if all checks are scaled,then "progress" is our guy.
        push @list_of_primes, $progress;
    }

    return \@list_of_primes;
}

1;