#!/usr/bin/python

from Hashes import IrreversibleEncryption

message = list("merry xmas")

one_way = IrreversibleEncryption()
hashed = one_way.hashWord(message)

print("Message is '", ''.join(message), "';\nMessage hash is ", hashed)
