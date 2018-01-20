package arithmetic;

public class Arithmetic {

    public static void main(String[] args) {
        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");
        
        /*
        * List Prime Numbers.
         */
        PrimeNumbers my_list = new PrimeNumbers(5, 500);
        System.out.println(my_list.getPrimes());
    }

}
