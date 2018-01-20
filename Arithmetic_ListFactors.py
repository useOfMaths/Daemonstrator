#!/usr/bin/python
from ListFactors import Factors

# Use the list factors module/class
test_guy = 48
factor_list = Factors(test_guy)
answer = factor_list.findFactors()
print("Factors of test_guy include:\n", " ".join(str(answer)))


print("\n\n")
