package COMBINATION;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2017.10;

	# Inherit from exporter to export functions and variables
	our @ISA = qw(Exporter);

	# Functions and variables to be exported by default
	our @EXPORT_OK = qw(possibleWordCombinations);
}

use warnings;
use strict;

my @words;
my $r; # min length of word
my @comb_store; # array of references
my $i;

# simulate an object construct
sub new {
	my $self = shift;
	
	my $this = {};
	bless $this, $self;
	
	return $this;
}

# point of entry
# returns an array reference of references to array strings
sub possibleWordCombinations {
	shift;
	my $arg = shift;
    @words = @{$arg};
    $r = shift;
    @comb_store = ();
    $i = 0;
    # check for conformity
    if ($r <= 0 || $r > scalar @words) {
        @comb_store = ();
    } elsif ($r == 1) {
        $comb_store[$_] = [$words[$_]] for (0 .. $#words);
    } else {
        progressiveCombination();
    }
    return \@comb_store;
}

# do combinations for all 'words' element
sub progressiveCombination {
	# anonymous reference to a single element array as 1st argument
    repetitivePairing([$words[$i]], $i + 1);
    if ($i + $r <= scalar @words) {
        # move on to next degree
        $i++;
        progressiveCombination();
    }
}

# do all possible combinations for 1st element of this array
sub repetitivePairing {
	my $prefix_word = shift; # array reference
	my $position = shift; # int
    my @auxiliary_store = ();
    for (0 .. ($#words - $position)) {
		# check if desired -- r -- size will be realised
        if ($_ + $i + $r <= scalar @words) {
			# dereference 'prefix_word' and save it as an anonymous array reference
			$auxiliary_store[$_] = [@{$prefix_word}];
			# save current 'word' to what 'aux_store[$_]' is referencing
			push @{$auxiliary_store[$_]}, $words[$position];
			if (scalar @{$auxiliary_store[$_]} < $r) {
				# 1st argument is an array reference - add next word on
				repetitivePairing($auxiliary_store[$_], $position + 1);
			} else {
				# save a reference '$auxiliary_store[$_]' to '@comb_store'
				push(@comb_store, $auxiliary_store[$_]);
			}
		}
		$position++;
    }
}

1;
