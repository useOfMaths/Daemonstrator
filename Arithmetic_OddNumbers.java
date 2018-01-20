package arithmetic;

public class Arithmetic {

    public static void main(String[] args) {
        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");
        
        /* Use the Odd Number class. */
        OddNumbers odd_data = new OddNumbers(1, 100); // odd numbers between 1 and 100
        System.out.println(odd_data.prepResult());

        System.out.println();
    }

}
