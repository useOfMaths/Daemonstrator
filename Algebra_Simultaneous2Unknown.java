package algebra;

public class Algebra {

    public static void main(String[] args) {

        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /*
            * Simultaneous Equations with 2 unknowns
         */
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
    }

}
