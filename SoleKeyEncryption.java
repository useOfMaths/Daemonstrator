package miscellaneous;

import java.math.BigInteger;

public class SoleKeyEncryption {

    public SoleKeyEncryption() {
    }

    public String[] encodeWord(char[] msg, char[] key) {
        // encoding eqn { Tn = 3^n-1(2t1 + 1) - 1 } - please use your own eqn
        //                        2
        String[] encryption = new String[msg.length];
        int n;
        int t1;
        BigInteger Tn;
        for (int i = 0; i < msg.length; i++) {
            // get unicode of this character as t1
            t1 = (int) msg[i];
            // get next key digit as n
            n = Integer.parseUnsignedInt(Character.toString(key[i % (key.length - 1)]), 16);
            // use recurrence series equation to encrypt & save in base 16
            Tn = BigInteger.valueOf(3).pow(n - 1).multiply(BigInteger.valueOf(2 * t1 + 1)).subtract(BigInteger.ONE).divide(BigInteger.valueOf(2));
            encryption[i] = Tn.toString(16);
        }

        return encryption;
    }

    public String decodeWord(String[] code, char[] key) {
        // decoding eqn { t1 = 3^1-n(2Tn + 1) - 1 }
        //                        2
        String decryption = "";
        int n;
        BigInteger t1;
        BigInteger Tn;
        for (int i = 0; i < code.length; i++) {
            Tn = new BigInteger(code[i], 16);
            // get next key digit as n
            n = Integer.parseUnsignedInt(Character.toString(key[i % (key.length - 1)]), 16);
            // use recurrence series equation to decrypt
            t1 = BigInteger.valueOf(2 * Tn.intValue() + 1).divide(BigInteger.valueOf(3).pow(n - 1)).subtract(BigInteger.ONE).divide(BigInteger.valueOf(2));
            decryption += Character.toString((char) t1.intValue());
        }

        return decryption;
    }
}
