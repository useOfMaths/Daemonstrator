#!/usr/bin/python
from ConditionalSelection import ConditionedChoice


# Use the combination module/class
goods = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]
# minimum number of occurrences
min_occurrence = [0, 0, 1, 0, 0, 1, 0, 0, 1, 0]
# maximum number of occurrences
max_occurrence = [4, 3, 2, 4, 3, 2, 4, 3, 2, 4]

choose = ConditionedChoice()
result = choose.limitedSelection(goods, 8, min_occurrence, max_occurrence)

# print choices and operation
print("\n", choose.words, " conditioned selection ", choose.r, ":\n")

# print out selections nicely
for group in result:
    print(group)
    
print("\n\nNumber of ways is ", len(result), ".\n")
