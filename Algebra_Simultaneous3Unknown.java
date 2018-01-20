package algebra;

import java.util.Arrays;

public class Algebra {

    public static void main(String[] args) {

        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("\n");

        int[] x_coeff;
        int[] y_coeff;
        int[] z_coeff;
        int[] equals;
        
        /*
        * Simultaneous Equations with 3 unknowns
         */
        char[][] operators = new char[3][2];
        for (char[] op : operators) {
            Arrays.fill(op, '+');
        }

        double[] result3D;
        x_coeff = new int[]{2, 4, 2};
        y_coeff = new int[]{1, -1, 3};
        z_coeff = new int[]{1, -2, -8};
        equals = new int[]{4, 1, -3};

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
