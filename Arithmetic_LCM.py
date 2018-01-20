#!/usr/bin/python
from LCM import findLCM

# Use the LCM module/class
group = [2, 3, 4]
lcm = findLCM(group)
answer = lcm.getLCM()
print("The L.C.M. of ", group, " is", answer, "\n")
