#!/usr/bin/python
from PrimeNumbers import ListPrimes

# Use the prime numbers module/class
lower_boundary = 1
upper_boundary = 100
prime_list = ListPrimes(lower_boundary, upper_boundary)
answer = prime_list.getPrimes()
print("Prime numbers between", lower_boundary, "and", upper_boundary, "are:\n", answer)


print("\n\n")
