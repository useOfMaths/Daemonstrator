# Sure enough this is a module

# define a class
class OpenEncryption:

    def __init__(self, semi_p):
        self.semi_prime = semi_p

    ##
    # STEP VI:
    ##
    def encodeWord(self, msg, key):
        encryption = []
        for i in range(len(msg)):
            # get unicode of this character as x
            x = ord(msg[i])
            # use RSA to encrypt & save in base 16
            encryption.append(hex(int(x**key % self.semi_prime))[2:]) # remove hex designator('0x')

        return encryption

    ##
    # STEP VII:
    ##
    def decodeWord(self, code, key):
        decryption = ""
        for i in range(len(code)):
            # use RSA to decrypt
            c = int(code[i], 16)**key % self.semi_prime
            decryption += chr(int(c))

        return decryption
