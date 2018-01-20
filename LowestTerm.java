package algebra;

public class LowestTerm {

    protected int numerator;
    protected int denominator;
    protected int trial_factor;

    public LowestTerm(int num, int denom) {
        numerator = num;
        denominator = denom;

        if (num < denom) {
            trial_factor = num;
        } else {
            trial_factor = denom;
        }

    }

    public int[] reduceFraction() {
        // We are counting down to test for mutual factors 
        while (trial_factor > 1) {
            // do we have a factor
            if ((numerator % trial_factor) == 0) {
                // is this factor mutual?
                if ((denominator % trial_factor) == 0) {
                    // where we have a mutual factor
                    numerator /= trial_factor;
                    denominator /= trial_factor;
                    continue; // continue with next iteration, repeating the current value of trial_factor
                }
            }
            trial_factor--;
        }
        return new int[]{numerator, denominator};
    }
}
