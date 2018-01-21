package miscellaneous;

import java.util.Arrays;
import java.util.List;
import java.math.BigInteger;

public class Miscellaneous {

    public static void main(String[] args) {
        /*
             * STEP I:
         */
        int p1 = 101; // 1st prime
        int p2 = 401; // 2nd prime
        /*
             * STEP II:
         */
        BigInteger semi_prime = BigInteger.valueOf(p1 * p2);

        /*
             * STEP III:
         */
        // get L.C.M. of p1-1 and p2-1
        List<Integer> stooge;
        stooge = Arrays.asList(p1 - 1, p2 - 1);
        LCM l_c_m = new LCM(stooge);
        int lcm = l_c_m.getLCM();

        /*
             * STEP IV:
         */
        // pick a random prime (public_key) that lies
        // between 1 and LCM but not a factor of LCM
        BigInteger public_key = BigInteger.valueOf(313);

        // find 'public_key' complement - private_key - such that
        // (public_key * private_key) % LCM = 1
        //this involves some measure of trial and error
        int i = 1;
        while ((lcm * i + 1) % public_key.intValue() != 0) {
            i++;
        }
        /*
             * STEP V:
         */
        BigInteger private_key = BigInteger.valueOf(i * lcm + 1).divide(public_key);

        char[] message = "merry xmas".toCharArray();
        DualKeyEncryption go_secure = new DualKeyEncryption(semi_prime);

        String[] encrypted = go_secure.encodeWord(message, public_key);
        System.out.println("Message is '" + String.valueOf(message) +
                "';\nEncrypted version is " + Arrays.toString(encrypted));

        String decrypted = go_secure.decodeWord(encrypted, private_key);
        System.out.println("\n\nDecrypted version is '" + decrypted + "'.");
    }

}
