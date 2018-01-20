#!/usr/bin/perl;
use strict;
use warnings;
use CHECKPRIME;

# Useful variables
my ($test_guy, $result);

# Use the check prime module/class
$test_guy = 98;
my $prime_check = CHECKPRIME->new($test_guy);
$result = "Prime State:\n";
if ($prime_check->verifyPrime()) {
    $result = "$test_guy is a prime number.";
} else {
    $result .= "$test_guy is not a prime number.\n";
    $result .= "At least one factor of $test_guy is " . $CHECKPRIME::a_factor;
}
print "$result\n";


print "\n\n";