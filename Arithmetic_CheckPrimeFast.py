#!/usr/bin/python
from CheckPrimeFast import TestPrimenessFast

# Use the check prime module/class
test_guy = 49
prime_check = TestPrimenessFast(test_guy)

result = "Prime State:\n"
if prime_check.verifyPrimeFast():
    result = "test_guy is a prime number."
else:
    result += "test_guy is not a prime number.\n"
    result += "At least one factor of test_guy is " + str(prime_check.a_factor)

print(result)


print("\n\n")
