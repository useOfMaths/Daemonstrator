#!/usr/bin/python
from Selection import Choice


# Use the combination module/class
goods = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]

pick = Choice()
result = pick.groupSelection(goods, 6)

# print choices and operation
print("\n", pick.words, " selection ", pick.r, ":\n")

# print out selections nicely
for group in result:
    print(group)
    
print("\n\nNumber of ways is ", len(result), ".\n")
