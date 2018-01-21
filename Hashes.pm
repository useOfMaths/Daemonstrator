package HASHES;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2017.10;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(encodeWord);
}

use warnings;
use strict;
use bigint;

# simulate an object construct
sub new {
	my $self = shift;
	
	my $this = {};
	bless $this, $self;
	
	return $this;
}

sub hashWord {
	shift;
	my $msg = shift;
    # encoding eqn { Tn = (n-2)t1 + 2^n } - please use your own eqn
    my $hashed;
    my $n;
    my $t1;
    my $x;
    for (0 .. $#{$msg}) {
        # get unicode of this character as n
        $n = ord($msg->[$_]);
        $t1 = $_ + 1;
            # use recurrence series equation to hash
            $x = ($n - 2) * $t1 + 2**$n;
            if ($_ == 0) {
                $hashed = $x;
                next;
			}
            # bitwise rotate left with the modulo of x
            my $binary = substr ($hashed->as_bin(), 2); # remove binary designator('0b')
            $x %= length $binary;

            my @slice_1 = split (//, substr($binary, $x));
            # keep as '1' to preserve hash size
            $slice_1[0] = "1";

            my $slice_2 = substr ($binary, 0, $x);

            $hashed = join("", @slice_1) . $slice_2;
            $hashed = Math::BigInt->from_bin($hashed);
    }
    $hashed = substr ($hashed->as_hex(), 2); # remove hex designator('0x')
	$hashed = uc $hashed;

    return $hashed;
}

1;
