package arithmetic;

public class Arithmetic {

    public static void main(String[] args) {
        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /*
        * List Prime Factors.
         */
        PrimeFactors prime_factors = new PrimeFactors(48);
        System.out.println(prime_factors.getPrimeFactors());
    }

}
