package EVENNUMBERS;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2016.12;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(prepResult);
}

use warnings;
use strict;

my ($start, $stop);
my @result;

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

# Simulate a constructor
sub _init {
	my $self = shift;
	($start, $stop) = @_;
}

# Returns an array reference of the desired set of even numbers
sub prepResult {
    # Loop from start to stop and rip out even numbers;
    until ($start > $stop) {
        if (($start % 2) == 0) { # modulo(%) is explained later
            push @result, $start;
        }
        $start = $start + 1; # increase start by 1
    }
    return \@result;
}

1;

