package SELECTION;

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

our @words;
our $r; # min length of word
my $i;
my @complete_group; # array of references

# simulate an object construct
sub new {
	my $self = shift;
	
	my $this = {};
	bless $this, $self;
	
	return $this;
}

# point of entry
# returns an array reference of references
sub groupSelection {
	shift;
	my $arg = shift;
    @words = @{$arg};
    $r = shift;
    @complete_group = ();
    $i = 0;
	
    recursiveFillUp([]);
    return \@complete_group;
}

# pick elements recursively
sub recursiveFillUp {
	my $temp = shift;
    my @picked_elements = ();
    my $j = $i;
	while ($j < scalar @words) {
		# dereference 'temp' and save it as an anonymous array reference
		$picked_elements[$j] = [@{$temp}];
		push @{$picked_elements[$j]}, $words[$j];
		# recoil factor
		$i = $j if $i >= scalar @words;
		# satisfied yet?
		if (scalar @{$picked_elements[$j]} == $r) {
			push @complete_group, $picked_elements[$j];
		} elsif (scalar @{$picked_elements[$j]} < $r) {
			recursiveFillUp($picked_elements[$j]);
		}
		$j++;
	}
	if (defined $picked_elements[--$j] && scalar @{$picked_elements[$j]} == $r) {
		$i++; # keep recoil factor straightened out
	}
}

1;
