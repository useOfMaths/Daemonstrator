#!/usr/bin/perl;
use strict;
use warnings;
use FASTHCF qw(getHCF);

# Useful variables
my $answer;
my @set;

# Use the fast HCF module/class
@set = (20, 30, 40);
my $h_c_f = FASTHCF->new(\@set);
$answer = $h_c_f->getHCF();
print ("The H.C.F. of ", join(", ", @set), " is $answer\n");


print "\n\n";