#!/usr/bin/python

from Combination import Combinatorial

# Use the combination module/class
goods = ["Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda"]

combo = Combinatorial()
result = combo.possibleWordCombinations(goods, 3)

# print choices and operation
print("\n", combo.words, " combination ", combo.r, ":\n")

# print out combinations nicely
for group in result:
    print(group)
    
print("\n\nNumber of ways is ", len(result), ".\n")
