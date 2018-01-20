#!/usr/bin/perl;
use strict;
use warnings;
use EVENNUMBERS;
use ODDNUMBERS;
use CHECKPRIME;
use PRIMENUMBERS;
use LISTFACTORS;
use LISTPRIMEFACTORS;
use HCF;
use FASTHCF qw(getHCF);
use LCM;

# Useful variables
my ($lower_boundary, $upper_boundary, $test_guy, $answer);
my @set;

# Use the even number module/class
$lower_boundary = 1;
$upper_boundary = 100;
my $even_list = EVENNUMBERS->new($lower_boundary, $upper_boundary);
$answer = $even_list->prepResult();
print "Even numbers between $lower_boundary and $upper_boundary are:\n@{$answer}\n";


print "\n\n";


# Use the odd number module/class
$lower_boundary = 1;
$upper_boundary = 100;
my $odd_list = ODDNUMBERS->new($lower_boundary, $upper_boundary);
$answer = $odd_list->prepResult();
print "Odd numbers between $lower_boundary and $upper_boundary are:\n@{$answer}\n";


print "\n\n";


# Collect Input
print "\n\nEnter the range for your odd numbers.\n";

print "Enter Start Number: ";
$lower_boundary = <STDIN>;
chomp $lower_boundary;

print "Enter Stop Number: ";
$upper_boundary = <STDIN>;
chomp $upper_boundary;

my $odd_list = ODDNUMBERS->new($lower_boundary, $upper_boundary);
$answer = $odd_list->prepResult();
print "Odd numbers between $lower_boundary and $upper_boundary are:\n@{$answer}\n";


print "\n\n";


# Use the check prime module/class
$test_guy = 97;
my $prime_check = CHECKPRIME->new($test_guy);
my $result = "Prime State:\n";
if ($prime_check->verifyPrimeFast()) {
    $result = "$test_guy is a prime number.";
} else {
    $result .= "$test_guy is not a prime number.\n";
    $result .= "At least one factor of $test_guy is " . $CHECKPRIME::a_factor;
}
print "$result\n";


print "\n\n";


# Use the prime numbers module/class
$lower_boundary = 1;
$upper_boundary = 100;
my $prime_list = PRIMENUMBERS->new($lower_boundary, $upper_boundary);
$answer = $prime_list->getPrimes();
print "Prime numbers between $lower_boundary and $upper_boundary are:\n@{$answer}\n";


print "\n\n";


# Use the list factors module/class
$test_guy = 48;
my $factor_list = LISTFACTORS->new($test_guy);
$answer = $factor_list->findFactors();
print ("Factors of $test_guy include:\n", join(", ", @{$answer}), "\n");


print "\n\n";


# Use the list prime factors module/class
$test_guy = 97;
my $prime_factors = LISTPRIMEFACTORS->new($test_guy);
$answer = $prime_factors->onlyPrimeFactors();
print ("Prime factorising $test_guy gives:\n", join(" X ", @{$answer}), "\n");


print "\n\n";


# Use the HCF module/class
@set = (20, 30, 40);
my $hcf = FASTHCF->new(\@set);
$answer = $hcf->getHCF();
print ("The H.C.F. of ", join(", ", @set), " is $answer\n");


print "\n\n";


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
		$user_num = lc $user_num;
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
} or die "Not sure about your input!";

# Use the fast HCF module/class
my $h_c_f = FASTHCF->new(\@set);
$answer = $h_c_f->getHCF();
print ("The H.C.F. of ", join(", ", @set), " is $answer\n");


print "\n\n";


# Use the LCM module/class
@set = (2, 3, 4);
my $lcm = LCM->new(\@set);
$answer = $lcm->getLCM();
print ("The L.C.M. of ", join(", ", @set), " is $answer\n");


