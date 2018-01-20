/*
 * This piece of code is the property of UseOfMaths.com
 * Its use is licensed under the GNU Terms and Conditions.
 * Feel free to adapt it aptly after reading the above license.
 */
package algebra;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 *
 * @author This Please!
 */
public class Algebra {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        int numerator;
        int denominator;
        int whole_number;
        List<Integer> numerators;
        List<Integer> denominators;
        int[] solution;

        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /*
        * Convert fractions from Mixed to Improper
         *//*
        whole_number = 3;
        numerator = 1;
        denominator = 3;

        System.out.println("Converting from Mixed to Improper the fraction:");
        // Print as fraction
        System.out.printf("%55d%n", numerator);
        System.out.printf("%54d%s%n", whole_number, "―");
        System.out.printf("%55d%n", denominator);

        // use the MixedToImproper class
        MixedToImproper mix_imp = new MixedToImproper(whole_number, numerator, denominator);
        numerator = mix_imp.doConvert();

        System.out.println();

        System.out.printf("%52d%n", numerator);
        System.out.printf("%51s%n", "Answer =  ―");
        System.out.printf("%52d%n", denominator);

        System.out.println("\n\n");
        

        /*
        * Convert fractions from Improper to Mixed
         *//*
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

        /*
        * Reduce fractions to Lowest Term
         *//*
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

        /*
        * Dividing fractions
         *//*
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


        /*
        * Adding fractions
         */
        numerators = new ArrayList<>();
        numerators.add(1);
        numerators.add(1);
        numerators.add(1);
        numerators.add(1);

        denominators = new ArrayList<>();
        denominators.add(4);
        denominators.add(4);
        denominators.add(4);
        denominators.add(4);

        System.out.println("Solving:");
        // Print as fraction
        for (int n : numerators) {
            System.out.printf("%13d", n);
        }
        System.out.println();
        System.out.printf("%12s", " ");
        for (int i = 0; i < numerators.size() - 1; i++) {
            System.out.print("―     +     ");
        }
        System.out.printf("%2s", "―");
        System.out.println();
        for (int d : denominators) {
            System.out.printf("%13d", d);
        }
        System.out.println();

        // use the AddFraction class
        AddFraction add_fract = new AddFraction(numerators, denominators);
        solution = add_fract.doAdd();
        numerator = solution[0];
        denominator = solution[1];

        System.out.println();

        System.out.printf("%25d%n", numerator);
        System.out.printf("%24s%n", "Answer =     ―");
        System.out.printf("%25d%n", denominator);

        System.out.println("\n\n");


        /*
        * Subtracting fractions
         *//*
        numerators = new ArrayList<>();
        numerators.add(9);
        numerators.add(3);
        numerators.add(5);
        numerators.add(7);

        denominators = new ArrayList<>();
        denominators.add(2);
        denominators.add(4);
        denominators.add(12);
        denominators.add(18);

        System.out.println("Solving:");
        // Print as fraction
        for (int n : numerators) {
            System.out.printf("%13d", n);
        }
        System.out.println();
        System.out.printf("%12s", " ");
        for (int i = 0; i < numerators.size() - 1; i++) {
            System.out.print("―     -     ");
        }
        System.out.printf("%2s", "―");
        System.out.println();
        for (int d : denominators) {
            System.out.printf("%13d", d);
        }
        System.out.println();

        // use the SubtractFraction class
        SubtractFraction sub_fract = new SubtractFraction(numerators, denominators);
        solution = sub_fract.doSubtract();
        numerator = solution[0];
        denominator = solution[1];

        System.out.println();

        System.out.printf("%25d%n", numerator);
        System.out.printf("%24s%n", "Answer =     ―");
        System.out.printf("%25d%n", denominator);

        System.out.println("\n\n");


        /*
        * Sorting fractions
         *//*
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
        

        
        /*
            * Simultaneous Equations with 2 unknowns
         *//*
        char[] operator = new char[]{'+', '+'};
        double[] result2D;
        double[] x_coeff = new double[]{1, -2};
        double[] y_coeff = new double[]{1, 1};
        double[] equals = new double[]{2, -1};

        if (y_coeff[0] < 0) {
            operator[0] = '-';
        }
        if (y_coeff[1] < 0) {
            operator[1] = '-';
        }

        System.out.println("Solving simultaneously the equations:");
        //Print as an equation
        System.out.printf("%40s%.2fx %s %.2fy = %.2f%n", "", x_coeff[0],
                operator[0], Math.abs(y_coeff[0]), equals[0]);
        System.out.printf("%40s%.2fx %s %.2fy = %.2f%n", "", x_coeff[1],
                operator[1], Math.abs(y_coeff[1]), equals[1]);
        System.out.printf("%n%30s%n%40s", "Yields:", "(x, y)  =  ");

        try {
            Simultaneous2Unknown sim2unk;
            sim2unk = new Simultaneous2Unknown(x_coeff, y_coeff, equals);
            result2D = sim2unk.solveSimultaneous();

            System.out.printf("(%.4f, %.4f)%n", result2D[0], result2D[1]);

        } catch (ArithmeticException e) {
            System.out.printf("(%s, %s)%n", "∞", "∞");
        }

        System.out.println("\n\n");
        

        /*
        * Simultaneous Equations with 3 unknowns
         */
        char[][] operators = new char[3][2];
        for (char[] op : operators) {
            Arrays.fill(op, '+');
        }

        double[] result3D;
        int[] x_coeff = new int[]{2, 4, 2};
        int[] y_coeff = new int[]{1, -1, 3};
        int[] z_coeff = new int[]{1, -2, -8};
        int[] equals = new int[]{4, 1, -3};

        for (int i = 0; i < 3; i++) {
            if (y_coeff[i] < 0) {
                operators[i][0] = '-';
            }
            if (z_coeff[i] < 0) {
                operators[i][1] = '-';
            }
        }

        System.out.println("Solving simultaneously the equations:");
        //Print as an equation
        System.out.printf(
                "%40dx %s %dy %s %dz = %d%n", x_coeff[0], operators[0][0],
                Math.abs(y_coeff[0]), operators[0][1], Math.abs(z_coeff[0]), equals[0]
        );
        System.out.printf(
                "%40dx %s %dy %s %dz = %d%n", x_coeff[1], operators[1][0],
                Math.abs(y_coeff[1]), operators[1][1], Math.abs(z_coeff[1]), equals[1]
        );
        System.out.printf(
                "%40dx %s %dy %s %dz = %d%n", x_coeff[2], operators[2][0],
                Math.abs(y_coeff[2]), operators[2][1], Math.abs(z_coeff[2]), equals[2]
        );
        System.out.printf("%n%30s%n%40s", "Yields:", "(x, y, z)  =  ");

        try {
            Simultaneous3Unknown sim3unk;
            sim3unk = new Simultaneous3Unknown(x_coeff, y_coeff, z_coeff, equals);
            result3D = sim3unk.solveSimultaneous();

            System.out.printf("(%.4f, %.4f, %.4f)%n", result3D[0], result3D[1], result3D[2]);

        } catch (ArithmeticException e) {
            System.out.printf("(%s, %s, %s)%n", "∞", "∞", "∞");
        }

    }

}
