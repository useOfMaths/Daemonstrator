package miscellaneous;

import java.util.Arrays;

public class Miscellaneous {

    public static void main(String[] args) {
        char[] message = "merry xmas".toCharArray();
        char[] key = "A5FB17C4D8".toCharArray(); // you might want to avoid zeroes
        SoleKeyEncryption go_secure = new SoleKeyEncryption();
        
        String[] encrypted = go_secure.encodeWord(message, key);
        System.out.println("Message is '" + String.valueOf(message) +
                "';\nEncrypted version is " + Arrays.toString(encrypted));
        
        String decrypted = go_secure.decodeWord(encrypted, key);
        System.out.println("\n\nDecrypted version is '" + decrypted + "'.");
    }

}