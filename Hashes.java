package miscellaneous;

import java.math.BigInteger;

public class Hashes {

    public Hashes() {
    }

    public String hashWord(char[] msg) {
        // encoding eqn { Tn = (n-2)t1 + 2^n } - please use your own eqn
        String hash = "";
        BigInteger n;
        BigInteger t1;
        BigInteger x;
        for (int i = 0; i < msg.length; i++) {
            // get unicode of this character as n
            n = BigInteger.valueOf((int) msg[i]);
            t1 = BigInteger.valueOf(i + 1);
            // use recurrence series equation to hash
            x = n.subtract(BigInteger.valueOf(2)).multiply(t1).add(BigInteger.valueOf(2).pow(n.intValue()));
            if (i == 0) {
                hash = x.toString();
                continue;
            }
            // bitwise rotate left with the modulo of x
            String binary = (new BigInteger(hash)).toString(2);
            x = x.mod(BigInteger.valueOf(binary.length()));

            char[] slice_1 = binary.substring(x.intValue()).toCharArray();
            // keep as '1' to preserve hash size
            slice_1[0] = '1';

            String slice_2 = binary.substring(0, x.intValue());

            hash = String.valueOf(slice_1) + slice_2;
            hash = (new BigInteger(hash, 2)).toString();
        }
        hash = (new BigInteger(hash)).toString(16);
        hash = hash.toUpperCase();

        return hash;
    }
}
