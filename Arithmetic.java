package arithmetic;

import java.awt.HeadlessException;
import java.util.Scanner;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JOptionPane;

public class Arithmetic {

    public static void main(String[] args) {
        /*System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /* Use the Even Number class. */
        /*String answer;
        
        evenNumbers even_data = new evenNumbers(1, 100); // even numbers between 1 and 100
        answer = even_data.prepResult();

        System.out.println(answer);

        System.out.println();
        
        /* Use the Odd Number class. */
        /*oddNumbers odd_data = new oddNumbers(1, 100); // odd numbers between 1 and 100
        System.out.println(odd_data.prepResult());

        System.out.println();
        
        /*
        * Collect input.
         */
        /*int first;
        int last;
        String collect_input; // For collecting user input

        /* Scanner takes care of collecting input using the System.in object. */
        Scanner user_choice = new Scanner(System.in);

        /*System.out.print("Enter your start number:   ");
        collect_input = user_choice.next(); // user input is a String object
        first = Integer.parseInt(collect_input); // Convert it to integer

        System.out.print("Enter your stop number:   ");
        collect_input = user_choice.next();
        last = Integer.parseInt(collect_input);

        // Use the Odd Number class.
        oddNumbers odd_input = new oddNumbers(first, last);
        odd_input.prepResult();

        System.out.println();
        
        /*
        * Test for the primeness of a number.
        */
        /*CheckPrime new_test = new CheckPrime(97); // Is 97 is prime number?
        System.out.println(new_test.verifyPrime());

        System.out.println();

        // Fast test for primeness
        new_test.verifyPrimeFast();
        
        /*
        * List Prime Numbers.
         */
        /*PrimeNumbers my_list = new PrimeNumbers(5, 500);
        System.out.println(my_list.getPrimes());

        /*
        * List Factors.
         */
        /*listFactors factors = new listFactors(48);
        System.out.println(factors.doBusiness());

        /*
        * List Prime Factors.
         */
        /*listPrimeFactors prime_factors = new listPrimeFactors(48);
        System.out.println(prime_factors.getPrimeFactors());

        /*
        * Find HCF.
         */
    /*String render_result = "The HCF of ";
        HCF hcf;*/
        List<Integer> set;

        set = new ArrayList<>();
        set.add(30);
        set.add(48);
        set.add(54);
/*
        for (int number : set) {
            render_result += number + "; ";
        }
        render_result += "is:  ";
        
        hcf = new HCF(set);
        System.out.println(render_result + hcf.getHCF());

    String render_result = "The HCF of ";
        for (int number : set) {
            render_result += number + "; ";
        }
        render_result += "is:  ";*/
        
        //Use fast copy
        FastHCF h_c_f;
        /*h_c_f = new FastHCF(set);
        System.out.println(render_result + h_c_f.getHCF());*/

        // Collect input
        String collect_input; // For collecting user input

        /* Scanner takes care of collecting input using the System.in object. */
        user_choice = new Scanner(System.in);
        
        //FastHCF h_c_f;
        //List<Integer> set;
        set = new ArrayList<>();

        System.out.println("Welcome to our Find HCF program.");
        System.out.println("Enter your series of number for HCF.");
        System.out.println("Type 'done' when you are through with entering your numbers.\n");
        System.out.print("Enter First Number:  ");
        try {
            do {
                collect_input = user_choice.next();
                if (collect_input.matches("[0-9]+")) {
                    if (Integer.parseInt(collect_input) != 0) {
                        set.add(Integer.parseInt(collect_input));
                        System.out.print("Enter Next Number:  ");
                    } else {
                        JOptionPane.showMessageDialog(null,
                                "You cannot enter zero. Repeat that!\nType 'done' when you're finished.");
                    }
                } else if (!"DONE".equals(collect_input.toUpperCase())) {
                    JOptionPane.showMessageDialog(null,
                            "Wrong Input. Repeat that!\nType 'done' when you're finished.");
                }
            } while (!"DONE".equals(collect_input.toUpperCase()));
        } catch (NumberFormatException | HeadlessException e) {
            System.out.println(e.getMessage());
        }
    String render_result = "The HCF of ";
        for (int number : set) {
            render_result += number + "; ";
        }
        render_result += "is:  ";

        h_c_f = new FastHCF(set);
        System.out.println(render_result + h_c_f.getHCF());

        /*
        * Find LCM.
         */
    /*String render_result = "The LCM of ";
        LCM lcm;
        List<Integer> group;

        group = new ArrayList<>();
        group.add(40);
        group.add(50);
        group.add(60);

        for (int number : group) {
            render_result += number + "; ";
        }
        render_result += "is:  ";
        
        lcm = new LCM(group);
        System.out.println(render_result + lcm.getLCM());*/

    }

}
