#!/usr/bin/perl;
use strict;
use warnings;
use LCM;

# Useful variables
my $answer;
my @set;

# Use the LCM module/class
@set = (2, 3, 4);
my $lcm = LCM->new(\@set);
$answer = $lcm->getLCM();
print ("The L.C.M. of ", join(", ", @set), " is $answer\n");


