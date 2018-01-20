package arithmetic;

import java.awt.HeadlessException;
import java.util.Scanner;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JOptionPane;

public class Arithmetic {

    public static void main(String[] args) {
        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        // Collect input
        String collect_input; // For collecting user input

        /* Scanner takes care of collecting input using the System.in object. */
        Scanner user_choice = new Scanner(System.in);

        FastHCF h_c_f;
        List<Integer> set;
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
    }

}
