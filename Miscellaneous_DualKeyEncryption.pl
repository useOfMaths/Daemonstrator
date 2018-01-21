#!/usr/bin/perl;

use strict;
use warnings;
use bigint;

use DUALKEYENCRYPTION;

##
# STEP I:
##
my $p1 = 101; # 1st prime
my $p2 = 401; # 2nd prime
##
# STEP II:
##
my $semi_prime = $p1 * $p2;

##
# STEP III:
##
use LCM;
my $lcm = LCM->new([$p1 - 1, $p2 - 1]);
$lcm = $lcm->getLCM();

##
# STEP IV:
##
# pick a random prime (public_key) that lies
# between 1 And LCM but Not a factor of LCM
my $public_key = 313;

# find "public_key" complement - private_key - such that
# (public_key * private_key) % LCM = 1
# this involves some measure of trial And error
my $i = 1;
while (($lcm * $i + 1) % $public_key != 0) {
    $i += 1;
}

##
# STEP V:
##
my $private_key = ($i * $lcm + 1) / $public_key;

my @message = split(//, "merry xmas");
my $go_secure = DUALKEYENCRYPTION->new($semi_prime);

my $encrypted = $go_secure->encodeWord(\@message, $public_key);
print("\nMessage is '", join("", @message), "';\nEncrypted version is ", join(", ", @{$encrypted}));

my $decrypted = $go_secure->decodeWord($encrypted, $private_key);
print("\n\nDecrypted version is '", $decrypted, "'.");

print "\n\n";