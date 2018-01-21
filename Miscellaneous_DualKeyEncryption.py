#!/usr/bin/python

from DualKeyEncryption import OpenEncryption

##
# STEP I:
##
p1 = 101 # 1st prime
p2 = 401 # 2nd prime
##
# STEP II:
##
semi_prime = p1 * p2

##
# STEP III:
##
from LCM import findLCM
l_c_m = findLCM([p1 - 1, p2 - 1])
lcm = int(l_c_m.getLCM())

##
# STEP IV:
##
# pick a random prime (public_key) that lies
# between 1 And LCM but Not a factor of LCM
public_key = 313

# find "public_key" complement - private_key - such that
# (public_key * private_key) % LCM = 1
# this involves some measure of trial And error
i = 1
while (lcm * i + 1) % public_key != 0:
    i += 1
##
# STEP V:
##
private_key = int((i * lcm + 1) / public_key)

message = list("merry xmas")
go_secure = OpenEncryption(semi_prime)

encrypted = go_secure.encodeWord(message, public_key)
print("Message is '", ''.join(message), "';\nEncrypted version is ", encrypted)

decrypted = go_secure.decodeWord(encrypted, private_key)
print("\nDecrypted version is '", decrypted, "'.")

