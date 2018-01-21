#!/usr/bin/perl;

use strict;
use warnings;

use SOLEKEYENCRYPTION;

my @message = split(//, "merry xmas");
my @key = split(//, "A5FB17C4D8"); # you might want To avoid zeroes
my $go_secure = SOLEKEYENCRYPTION->new();

my $encrypted = $go_secure->encodeWord(\@message, \@key);
print ("\nMessage is '", join("", @message), "';\nEncrypted version is ", join(", ", @{$encrypted}));

my $decrypted = $go_secure->decodeWord($encrypted, \@key);
print("\n\nDecrypted version is '", $decrypted, "'.");

print "\n\n";