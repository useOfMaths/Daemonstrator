package miscellaneous;

import java.math.BigInteger;

public class DualKeyEncryption {

    BigInteger semi_prime;

    public DualKeyEncryption(BigInteger semi_prime) {
        this.semi_prime = semi_prime;
    }

    /*
     * STEP VI:
     */
    public String[] encodeWord(char[] msg, BigInteger key) {
        String[] encryption = new String[msg.length];
        int x;
        for (int i = 0; i < msg.length; i++) {
            // get unicode of this character as x
            x = (int) msg[i];
            // use RSA to encrypt & save in base 16
            encryption[i] = BigInteger.valueOf(x).modPow(key, semi_prime).toString(16);
        }

        return encryption;
    }

    /*
     * STEP VII:
     */
    public String decodeWord(String[] code, BigInteger key) {
        String decryption = "";
        int c;
        for (int i = 0; i < code.length; i++) {
            // use RSA to decrypt
            c = (new BigInteger(code[i], 16)).modPow(key, semi_prime).intValue();
            decryption += Character.toString((char) c);
        }

        return decryption;
    }
}
