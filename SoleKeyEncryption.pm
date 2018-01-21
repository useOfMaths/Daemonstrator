package SOLEKEYENCRYPTION;

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

# simulate an object construct
sub new {
	my $self = shift;
	
	my $this = {};
	bless $this, $self;
	
	return $this;
}

sub encodeWord {
	shift;
	my $msg = shift;
	my $key = shift;
	# encoding eqn { Tn = 3^n-1(2t1 + 1) - 1 } - please use your own eqn
	#                        2
	my @encryption = ();
	my $n;
	my $t1;
	my $Tn;
	for (0 .. $#{$msg}) {
		# get unicode of this character as t1
		$t1 = ord($msg->[$_]);
		# get next key digit as n
		$n = hex($key->[$_ % ((scalar @{$key}) - 1)]);
		# use recurrence series equation to encrypt & save in base 16
		$Tn = (3**($n - 1) * (2 * $t1 + 1) - 1) / 2;
		push (@encryption, substr ($Tn->as_hex(), 2)); # remove hex designator('0x')
	}

	return \@encryption;
}

sub decodeWord {
	shift;
	my $code = shift;
	my $key = shift;
	# decoding eqn { t1 = 3^1-n(2Tn + 1) - 1 }
	#                        2
	my $decryption = "";
	my $n;
	my $t1;
	my $Tn;
	for (0 .. $#{$code}) {
		$Tn = hex($code->[$_]);
		# get next key digit as n
		$n = hex($key->[$_ % ((scalar @{$key}) - 1)]);
		# use recurrence series equation to decrypt
		$t1 = ((2 * $Tn + 1) / 3**($n - 1) - 1) / 2;
		$decryption .= chr($t1);
	}

	return $decryption;
}

1;
