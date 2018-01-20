package algebra;

import java.util.ArrayList;
import java.util.List;

public class Algebra {

    public static void main(String[] args) {

        List<Integer> numerators;
        List<Integer> denominators;

        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /*
        * Sorting fractions
         */
        numerators = new ArrayList<>();
        numerators.add(1);
        numerators.add(3);
        numerators.add(5);
        numerators.add(9);

        denominators = new ArrayList<>();
        denominators.add(2);
        denominators.add(4);
        denominators.add(2);
        denominators.add(10);

        System.out.println("Sorting in ascending order the fractions:");
        // Print as fraction
        System.out.printf("%35s", " ");
        for (int n : numerators) {
            System.out.printf("%9d", n);
        }
        System.out.println();
        System.out.printf("%43s", " ");
        for (int i = 0; i < numerators.size() - 1; i++) {
            System.out.print("― ,     ");
        }
        System.out.printf("%2s", "―");
        System.out.println();
        System.out.printf("%35s", " ");
        for (int d : denominators) {
            System.out.printf("%9d", d);
        }
        System.out.println();

        // use the SortFraction class
        SortFraction sort_fract = new SortFraction(numerators, denominators);
        sort_fract.sortAscending();
        numerators = sort_fract.final_numerators;
        denominators = sort_fract.final_denominators;

        System.out.println();

        // Print as fraction
        System.out.printf("%35s", " ");
        for (int n : numerators) {
            System.out.printf("%9d", n);
        }
        System.out.println();
        System.out.printf("%43s", "Answer =    ");
        for (int i = 0; i < numerators.size() - 1; i++) {
            System.out.print("― ,     ");
        }
        System.out.printf("%2s", "―");
        System.out.println();
        System.out.printf("%35s", " ");
        for (int d : denominators) {
            System.out.printf("%9d", d);
        }
        System.out.println();

        System.out.println("\n\n");
    }

}
