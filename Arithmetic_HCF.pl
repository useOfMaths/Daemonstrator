#!/usr/bin/perl;
use strict;
use warnings;
use HCF;

# Useful variables
my $answer;
my @set;

# Use the HCF module/class
@set = (20, 30, 40);
my $hcf = HCF->new(\@set);
$answer = $hcf->getHCF();
print ("The H.C.F. of ", join(", ", @set), " is $answer\n");


print "\n\n";