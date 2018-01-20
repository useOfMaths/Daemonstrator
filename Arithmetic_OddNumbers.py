#!/usr/bin/python
from OddNumbers import OddNumerals

# Use the even number module/class
lower_boundary = 1
upper_boundary = 100
odd_list = OddNumerals(lower_boundary, upper_boundary)
answer = odd_list.prepResult()
print("Even numbers between", lower_boundary, "and", upper_boundary, "are:\n", answer)


print("\n\n")
