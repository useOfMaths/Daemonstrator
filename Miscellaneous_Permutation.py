#!/usr/bin/python
from Permutation import Transposition


# Use the combination module/class
goods = ["Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda"]

perm = Transposition()
result = perm.possibleWordPermutations(goods, 9)

# print choices and operation
print("\n", perm.words, " permutation ", perm.r, ":\n")

# print out permutations nicely
for group in result:
    print(group)
    
print("\n\nNumber of ways is ", len(result), ".\n")
