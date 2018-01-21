package DUALKEYENCRYPTION;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2017.10;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(encodeWord decodeWord);
}

use warnings;
use strict;
use bigint;

my $semi_prime;

# simulate an object construct
sub new {
	my $self = shift;
	$semi_prime = shift;
	
	my $this = {};
	bless $this, $self;
	
	return $this;
}

##
 # STEP VI:
 ##
sub encodeWord {
	shift;
	my $msg = shift;
	my $key = shift;
    my @encryption = ();
    my $x;
    for (0 .. $#{$msg}) {
        # get unicode of this character as x
		$x = ord($msg->[$_]);
		# use RSA to encrypt & save in base 16
		push (@encryption, substr (($x**$key % $semi_prime)->as_hex(), 2)); # remove hex designator('0x')
    }

    return \@encryption;
}

##
 # STEP VII:
 ##
sub decodeWord {
	shift;
	my $code = shift;
	my $key = shift;
    my $decryption = "";
    my $c;
    for (0 .. $#{$code}) {
		# use RSA to decrypt
		$c = hex($code->[$_])**$key % $semi_prime;
		$decryption .= chr($c);
    }

    return $decryption;
}

1;
