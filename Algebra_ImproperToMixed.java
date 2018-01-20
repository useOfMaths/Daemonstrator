package algebra;

import java.util.List;

public class Algebra {

    public static void main(String[] args) {

        int numerator;
        int denominator;
        int whole_number;
        int[] solution;

        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");
        
        /*
        * Convert fractions from Improper to Mixed
         */
        numerator = 10;
        denominator = 3;

        System.out.println("Converting from Improper to Mixed the fraction:");
        // Print as fraction
        System.out.printf("%55d%n", numerator);
        System.out.printf("%54s%n", "―");
        System.out.printf("%55d%n", denominator);

        // use the ImproperToMixed class
        ImproperToMixed imp_mix = new ImproperToMixed(numerator, denominator);
        solution = imp_mix.doConvert();
        whole_number = solution[0];
        numerator = solution[1];

        System.out.println();

        System.out.printf("%52d%n", numerator);
        System.out.printf("%50s%d%s%n", "Answer =  ", whole_number, "―");
        System.out.printf("%52d%n", denominator);

        System.out.println("\n\n");
    }

}
