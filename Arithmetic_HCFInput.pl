#!/usr/bin/perl;
use strict;
use warnings;
use FASTHCF qw(getHCF);

# Useful variables
my ($lower_boundary, $upper_boundary, $test_guy, $answer);
my @set;

# Collect input
print "\nWelcome to our Find HCF program.\n";
print "Enter your series of numbers whose HCF you wish to find.\n";
print "\nType 'done' when you are through with entering your numbers.\n";
print "Enter First Number:  ";

@set = ();
my $user_num;

eval {
	do {
		# get keyboard input
		$user_num = <>;
		chomp $user_num;
		# Convert 'user_num' to upper case.
		$user_num = uc $user_num;
		# Make sure input is a number
		if ($user_num =~ /[0-9]+/) {
			if ($user_num != 0) {
				push @set, $user_num;
				print "Enter Next Number:  ";
			} else {
				print "\nYou cannot enter zero. Repeat that!\nType 'done' when you're finished.\n";
			}
		} elsif ($user_num ne "DONE") {
			print "\nWrong Input. Repeat that!\nType 'done' when you're finished.\n";
		}
	} while ($user_num ne "DONE");
};

# Use the fast HCF module/class
my $h_c_f = FASTHCF->new(\@set);
$answer = $h_c_f->getHCF();
print ("The H.C.F. of ", join(", ", @set), " is $answer\n");


print "\n\n";