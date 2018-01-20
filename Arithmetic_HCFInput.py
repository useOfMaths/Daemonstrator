#!/usr/bin/python
from FastHCF import quickHCF
import re

# Collect input
print("\nWelcome to our Find HCF program.\
Enter your series of numbers whose HCF you wish to find.\
\nType 'done' when you are through with entering your numbers.")

group = []
collect_input_text = "Enter First Number:  ";
user_num = "start"

try:
    while user_num != "DONE":
        # get keyboard input
        user_num = input(collect_input_text)
        # Make sure input is a number
        if re.search("[0-9]+", user_num):
            user_num = int(user_num)
            if user_num != 0:
                group.append(user_num)
                collect_input_text = "Enter Next Number:  "

            else:
                print("\nYou cannot enter zero. Repeat that!\nType 'done' when you're finished.\n")

        else:
            # Convert 'user_num' to upper case.
            user_num = user_num.upper()
            if user_num != "DONE":
                print("\nWrong Input. Repeat that!\nType 'done' when you're finished.\n")

except:
    print("Sorry, but something must have gone wrong!")

# Use the fast HCF module/class
h_c_f = quickHCF(group)
answer = h_c_f.getHCF()
print ("The H.C.F. of ", group, "is", answer)


print("\n\n")
