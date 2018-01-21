package miscellaneous;

public class Miscellaneous {

    public static void main(String[] args) {
        char[] message = "merry xmas".toCharArray();
        
        Hashes one_way = new Hashes();
        String hashed = one_way.hashWord(message);
        
        System.out.println("Message is '" + String.valueOf(message) +
                "';\nMessage hash is " + hashed);
    }

}