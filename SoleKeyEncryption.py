# Sure enough this is a module

# define a class
class ClosedEncryption:

    def __init__(self):
        self.i = 0

    def encodeWord(self, msg, key):
        # encoding eqn { Tn = 3^n-1(2t1 + 1) - 1 } - please use your own eqn
        #                        2
        encryption = []
        for i in range(len(msg)):
            # get unicode of this character as t1
            t1 = ord(msg[i])
            # get next key digit as n
            n = int(key[i % (len(key) - 1)], 16)
            # use recurrence series equation to encrypt & save in base 16
            Tn = (3**(n - 1) * (2 * t1 + 1) - 1) / 2
            encryption.append(hex(int(Tn))[2:]) # remove hex designator('0x')

        return encryption


    def decodeWord(self, code, key):
        # decoding eqn { t1 = 3^1-n(2Tn + 1) - 1 }
        #                        2
        decryption = ""
        for i in range(len(code)):
            Tn = int(code[i], 16)
            # get next key digit as n
            n = int(key[i % (len(key) - 1)], 16)
            # use recurrence series equation to decrypt
            t1 = ((2 * Tn + 1) / 3**(n - 1) - 1) / 2
            decryption += chr(int(t1))

        return decryption

