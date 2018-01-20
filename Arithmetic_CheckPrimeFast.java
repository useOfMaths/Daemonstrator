package arithmetic;

public class Arithmetic {

    public static void main(String[] args) {
        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");
        
        /*
        * Test for the primeness of a number.
        */
        CheckPrime new_test = new CheckPrime(97); // Is 97 is prime number?
        System.out.println(new_test.verifyPrimeFast());

        System.out.println();
    }

}
