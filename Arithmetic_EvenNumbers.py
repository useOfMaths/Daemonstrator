#!/usr/bin/python
from EvenNumbers import EvenNumerals

# Use the even number module/class
lower_boundary = 1
upper_boundary = 100
even_list = EvenNumerals(lower_boundary, upper_boundary)
answer = even_list.prepResult()
print("Even numbers between", lower_boundary, "and", upper_boundary, "are:\n", answer)


print("\n\n")
