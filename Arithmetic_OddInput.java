package arithmetic;

import java.util.Scanner;

public class Arithmetic {

    public static void main(String[] args) {
        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");
        
        /*
        * Collect input.
         */
        int first;
        int last;
        String collect_input; // For collecting user input

        /* Scanner takes care of collecting input using the System.in object. */
        Scanner user_choice = new Scanner(System.in);

        System.out.print("Enter your start number:   ");
        collect_input = user_choice.next(); // user input is a String object
        first = Integer.parseInt(collect_input); // Convert it to integer

        System.out.print("Enter your stop number:   ");
        collect_input = user_choice.next();
        last = Integer.parseInt(collect_input);

        // Use the Odd Number class.
        OddNumbers odd_input = new OddNumbers(first, last);
        System.out.println(odd_input.prepResult());

        System.out.println();
    }

}
