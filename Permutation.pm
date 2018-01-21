package PERMUTATION;

BEGIN {
	require Exporter;

	# for the sake of standard
	our $VERSION = 2017.10;

	# Inherit from exporter to export subs and variables
	our @ISA = qw(Exporter);

	# subs and variables to be exported by default
	our @EXPORT_OK = qw(possibleWordPermutations);
}

use 5.010;
use warnings;
use strict;

our @words;
our $r; # min length of word
my @local_store; # array of references
my @perm_store; # array of references
my $eye;
my $combination;

# simulate an object construct
sub new {
	my $self = shift;
	
	my $this = {};
	bless $this, $self;
	
	return $this;
}

# till the ground for shuffle to grind on
# returns an array reference of references to array strings
sub possibleWordPermutations {
	shift;
	my $arg = shift;
    @words = @{$arg};
    $r = shift;
    @perm_store = ();
	
	use COMBINATION;
	my $call = COMBINATION->new();
	# $combination receives an array reference of references
    $combination = $call->possibleWordCombinations(\@words, $r);
	
    # illegal 'r' value
    if (!defined $combination->[0] || $r == 1) {
        @perm_store = @{$combination};
    } else {
		
		for (0 .. $#{$combination}) {
			$eye = $r - 1;
			# copy up last two elements of 'comb_store.get(i)'
			my @last_two = (["", ""], ["", ""]); # array of references
			$last_two[0]->[0] = $last_two[1]->[1] = $combination->[$_]->[$eye--];
			$last_two[0]->[1] = $last_two[1]->[0] = $combination->[$_]->[$eye--];
			
			@local_store = (); # array of references
			push @local_store, $last_two[0], $last_two[1];
			shuffleWord([@local_store], $_) if $r > 2;

			push @perm_store, @local_store;
		}
    }
    return \@perm_store;
}

sub shuffleWord {
	my $arg_store = shift; # array reference of references
    my $i = shift;
	@local_store = ();
	my @members;
	for my $entry (@{$arg_store}) {
		@members = @{$entry};
		# add 'comb_store[i][eye]' element to this list of members
		push @members, $combination->[$i]->[$eye];

		my $shift_index = scalar @members;
		# shuffle this pack of words
		while ($shift_index > 0) {
			# skip if already in store -- /* array comparism */
			my ($contains) = grep { @{$local_store[$_]} ~~ @members } 0 .. $#local_store;
			if (!defined $contains) {
				push @local_store, [@members];
			}
			# interchange these two neighbours
			if (--$shift_index > 0 && $members[$shift_index] ne $members[$shift_index - 1]) {
				@members[$shift_index - 1, $shift_index] = @members[$shift_index, $shift_index - 1];
			}
		}
	}
	# Are there any elements left? repeat if yes
	if ($eye-- > 0) {
		shuffleWord([@local_store], $i);
	}
}

1;
