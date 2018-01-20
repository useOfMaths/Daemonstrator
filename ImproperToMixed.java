package algebra;

public class ImproperToMixed {

    private final int numerator;
    private final int denominator;
    private int whole_number;
    private int new_numerator;

    public ImproperToMixed(int num, int denom) {
        numerator = num;
        denominator = denom;
    }

    public int[] doConvert() {
        int dividend; // Highest multiple of denominator less than numerator
        for (dividend = numerator - 1; dividend > 1; dividend--) {
            if ((dividend % denominator) == 0) {
                new_numerator = numerator - dividend;
                whole_number = dividend / denominator;
                break;
            }
        }
        return new int[]{whole_number, new_numerator};
    }
}
