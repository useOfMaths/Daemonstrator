#!/usr/bin/perl;

use strict;
use warnings;

use HASHES;

my @message = split(//, "merry xmas");

my $one_way = HASHES->new();
my $hashed = $one_way->hashWord(\@message);

print("Message is '", join("", @message), "';\nMessage hash is ", $hashed);

print "\n\n";