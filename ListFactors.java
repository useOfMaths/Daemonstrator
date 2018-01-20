package arithmetic;

import java.util.ArrayList;
import java.util.List;
import java.util.Comparator;

public class ListFactors {

    private final List<Integer> found_factors;
    private final int find_my_factors;
    private final int sqrt_range; // Use this range for our loop
    private Comparator c; // For sorting arraylists. It is left as 'null'.

    ListFactors(int candidate) {
        found_factors = new ArrayList<>();
        find_my_factors = candidate;
        sqrt_range = (int) Math.ceil(Math.sqrt(find_my_factors));
    }

    /**
     * Does the main job of finding the requested factors.
     * @return - String value
     */
    public String doBusiness() {
        /* Loop through 1 to 'find_my_factors' and test for divisibility. */
        for (int i = 1; i < sqrt_range; i++) {
            if ((find_my_factors % i) == 0) {
                found_factors.add(i);
                /* Get the complementing factor by dividing 'find_my_factor' by variable i. */
                found_factors.add(find_my_factors / i);
            }
        }

        // Sort the array in ascending order; Not entirely necessary.
        found_factors.sort(c);

        return ("The factors of " + find_my_factors + " are: \n" + found_factors);
    }

}
