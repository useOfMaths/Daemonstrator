#!/usr/bin/python
from CheckPrime import TestPrimeness

# Use the check prime module/class
test_guy = 97
prime_check = TestPrimeness(test_guy)
result = "Prime State:\n"
if prime_check.verifyPrime():
    result = "test_guy is a prime number."
else:
    result += "test_guy is not a prime number.\n"
    result += "At least one factor of test_guy is " + str(prime_check.a_factor)

print(result)


print("\n\n")
