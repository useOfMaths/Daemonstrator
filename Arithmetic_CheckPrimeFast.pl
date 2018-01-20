#!/usr/bin/perl;
use strict;
use warnings;
use CHECKPRIMEFAST;

# Useful variables
my ($test_guy, $result);

# Use the check prime module/class
$test_guy = 49;
my $prime_check = CHECKPRIMEFAST->new($test_guy);
$result = "Prime State:\n";
if ($prime_check->verifyPrimeFast()) {
    $result = "$test_guy is a prime number.";
} else {
    $result .= "$test_guy is not a prime number.\n";
    $result .= "At least one factor of $test_guy is " . $CHECKPRIMEFAST::a_factor;
}
print "$result\n";


print "\n\n";