package algebra;

import java.util.List;

public class MultiplyFraction {

    protected final List<Integer> numerators;
    protected final List<Integer> denominators;
    protected final int[] answer = {1, 1};
    protected int n_index, d_index;
    protected int trial_factor;
    protected boolean mutual_factor;

    public MultiplyFraction(List<Integer> num, List<Integer> denom) {
        numerators = num;
        denominators = denom;
        trial_factor = 0;
        n_index = 0;
        d_index = 0;

        for (int n : num) {
            if (n > trial_factor) {
                trial_factor = n;
            }
        }
        for (int d : denom) {
            if (d > trial_factor) {
                trial_factor = d;
            }
        }
    }

    public int[] doMultiply() {

        // We are counting down to test for mutual factors 
        while (trial_factor > 1) {
            // iterate through numerators and check for factors
            while (n_index < numerators.size()) {
                mutual_factor = false;
                if ((numerators.get(n_index) % trial_factor) == 0) { // do we have a factor
                    // iterate through denominators and check for factors
                    while (d_index < denominators.size()) {
                        if ((denominators.get(d_index) % trial_factor) == 0) { // is this factor mutual?
                            mutual_factor = true;
                            break; // stop as soon as we find a mutual factor so preserve the corresponding index
                        }
                        d_index++;
                    }
                    break; // stop as soon as we find a mutual factor so as  preserve the corresponding index
                }
                n_index++;
            }
            // where we have a mutual factor
            if (mutual_factor) {
                numerators.set(n_index, numerators.get(n_index) / trial_factor);
                denominators.set(d_index, denominators.get(d_index) / trial_factor);
                continue; // continue with next iteration repeating the current value of trial_factor
            }
            n_index = 0;
            d_index = 0;
            trial_factor--;
        }

        for (int i = 0; i < numerators.size(); i++) {
            answer[0] *= numerators.get(i);
            answer[1] *= denominators.get(i);
        }

        return answer;
    }
}
