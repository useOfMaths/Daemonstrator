package algebra;

import java.util.ArrayList;
import java.util.List;

public class Algebra {

    public static void main(String[] args) {

        List<Integer> numerators;
        List<Integer> denominators;
        int[] solution;

        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /*
        * Multiplying fractions
         */
        numerators = new ArrayList<>();
        numerators.add(16);
        numerators.add(20);
        numerators.add(27);
        numerators.add(20);

        denominators = new ArrayList<>();
        denominators.add(9);
        denominators.add(9);
        denominators.add(640);
        denominators.add(7);

        System.out.println("Solving:");
        // Print as fraction
        for (int n : numerators) {
            System.out.printf("%13d", n);
        }
        System.out.println();
        System.out.printf("%12s", " ");
        for (int i = 0; i < numerators.size() - 1; i++) {
            System.out.print("―     X     ");
        }
        System.out.printf("%1s", "―");
        System.out.println();
        for (int d : denominators) {
            System.out.printf("%13d", d);
        }
        System.out.println();

        // use the MultiplyFraction class
        MultiplyFraction mul_fract = new MultiplyFraction(numerators, denominators);
        solution = mul_fract.doMultiply();

        System.out.println();

        System.out.printf("%25d%n", solution[0]);
        System.out.printf("%24s%n", "Answer = ―");
        System.out.printf("%25d%n", solution[1]);

        System.out.println("\n\n");
    }

}
