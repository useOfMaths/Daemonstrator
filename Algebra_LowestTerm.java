package algebra;

public class Algebra {

    public static void main(String[] args) {

        int numerator;
        int denominator;
        int[] solution;

        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /*
        * Reduce fractions to Lowest Term
         */
        numerator = 16;
        denominator = 640;

        System.out.println("To reduce to lowest term, simplifying:");
        // Print as fraction
        System.out.printf("%45d%n", numerator);
        System.out.printf("%44s%n", "―");
        System.out.printf("%45d%n", denominator);

        // use the LowestTerm class
        LowestTerm red_fract = new LowestTerm(numerator, denominator);
        solution = red_fract.reduceFraction();
        numerator = solution[0];
        denominator = solution[1];

        System.out.println();

        System.out.printf("%46d%n", numerator);
        System.out.printf("%45s%n", "Answer =    ―");
        System.out.printf("%46d%n", denominator);

        System.out.println("\n\n");
    }

}
