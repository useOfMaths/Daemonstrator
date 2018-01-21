#!/usr/bin/python

from SoleKeyEncryption import ClosedEncryption

message = list("merry xmas")
key = list("A5FB17C4D8") # you might want To avoid zeroes
go_secure = ClosedEncryption()

encrypted = go_secure.encodeWord(message, key)
print("Message is '", ''.join(message), "';\nEncrypted version is ", encrypted)

decrypted = go_secure.decodeWord(encrypted, key)
print("\nDecrypted version is '", decrypted, "'.")
