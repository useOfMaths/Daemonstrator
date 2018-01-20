package algebra;

import java.util.ArrayList;
import java.util.List;

public class Algebra {

    public static void main(String[] args) {

        int numerator;
        int denominator;
        List<Integer> numerators;
        List<Integer> denominators;
        int[] solution;

        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /*
        * Dividing fractions
         */
        numerators = new ArrayList<>();
        numerators.add(16);
        numerators.add(9);
        numerators.add(640);
        numerators.add(7);

        denominators = new ArrayList<>();
        denominators.add(9);
        denominators.add(20);
        denominators.add(27);
        denominators.add(20);

        System.out.println("Solving:");
        // Print as fraction
        for (int n : numerators) {
            System.out.printf("%13d", n);
        }
        System.out.println();
        System.out.printf("%12s", " ");
        for (int i = 0; i < numerators.size() - 1; i++) {
            System.out.print("―     ÷     ");
        }
        System.out.printf("%2s", "―");
        System.out.println();
        for (int d : denominators) {
            System.out.printf("%13d", d);
        }
        System.out.println();

        // use the DivideFraction class
        DivideFraction div_fract = new DivideFraction(numerators, denominators);
        solution = div_fract.doDivide();
        numerator = solution[0];
        denominator = solution[1];

        System.out.println();

        System.out.printf("%25d%n", numerator);
        System.out.printf("%24s%n", "Answer = ―");
        System.out.printf("%25d%n", denominator);

        System.out.println("\n\n");
    }

}
