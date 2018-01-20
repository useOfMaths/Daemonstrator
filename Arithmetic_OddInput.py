from OddNumbers import OddNumerals

# Collect Input
print("\n\nEnter the range for your odd numbers.\n")

lower_boundary = int(input("Enter Start Number: "))
upper_boundary = int(input("Enter Stop Number: "))

odd_list = OddNumerals(lower_boundary, upper_boundary)
answer = odd_list.prepResult()
print("Even numbers between", lower_boundary, "and", upper_boundary, "are:\n", answer)


print("\n\n");
