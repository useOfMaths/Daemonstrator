package CONDITIONALSELECTION;

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

# simulate an object construct
sub new {
	my $self = shift;
	
	my $this = {};
	bless $this, $self;
	
	return $this;
}

# point of entry
# returns an array reference of references
sub limitedSelection {
	shift;
	my $arg = shift;
    my @words = @{$arg};
    my $r = shift;
	my $minimum = shift; # array reference
	my $maximum = shift; # array reference
    my @final_elements = (); # array of references
	
	use SELECTION;
	my $call = SELECTION->new();
	# $selection receives an array reference of references
    my $selection = $call->groupSelection(\@words, $r);
	
    for my $option (@{$selection}) {
        my $state = 0;
        for my $i (0 .. $#words) {
			# get 'words[j]' frequency/count in group
            my $count = grep {$_ eq $words[$i]} @{$option};
            if ($count >= $minimum->[$i] && $count <= $maximum->[$i]) {
                 $state = 1;
            } else {
                $state = 0;
                last;
            }
        }
        # skip if already in net
        if ($state) {
            push @final_elements, $option;
        }
    }
    return \@final_elements;
}

1;
