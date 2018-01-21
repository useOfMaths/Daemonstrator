# Sure enough this is a module

# define a class
class IrreversibleEncryption:

    def __init__(self):
        self.i = 0

    def hashWord(self, msg):
        # encoding eqn { Tn = (n-2)t1 + 2^n } - please use your own eqn
        hashed = 0
        for i in range(len(msg)):
            # get unicode of this character as n
            n = ord(msg[i])
            t1 = i + 1
            # use recurrence series equation to hash
            x = (n - 2) * t1 + 2**n
            if i == 0:
                hashed = x
                continue

            # bitwise rotate left with the modulo of x
            binary = (bin(hashed))[2:] # remove binary designator('0b')
            x %= len(binary)

            slice_1 = list(binary[x:])
            # keep as '1' to preserve hash size
            slice_1[0] = "1"

            slice_2 = binary[0:x]

            hashed = "".join(slice_1) + slice_2
            hashed = int(hashed, 2)

        hashed = (hex(hashed))[2:] # remove hex designator('0x')
        hashed = hashed.upper()

        return hashed
