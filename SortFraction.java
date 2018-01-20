package algebra;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class SortFraction extends AddFraction {

    public List<Integer> final_numerators;
    public List<Integer> final_denominators;

    public SortFraction(List<Integer> num, List<Integer> denom) {
        super(num, denom);
        final_numerators = new ArrayList<>();
        final_denominators = new ArrayList<>();
    }

    public void sortAscending() {
        List<Integer> copy_numerators = new ArrayList<>();
        int index;

        canonizeFraction();

        for (Integer nn : new_numerators) {
            copy_numerators.add(nn);
        }

        Collections.sort(copy_numerators);

        // map sorted (transformed) fractions to the original ones
        for (Integer sorted : copy_numerators) {
            // get index using array value
            index = new_numerators.indexOf(sorted);
            final_numerators.add(super.numerators.get(index));
            final_denominators.add(super.denominators.get(index));
        }
    }

    public void sortDescending() {
        List<Integer> copy_numerators = new ArrayList<>();
        int index;

        canonizeFraction();

        for (Integer nn : new_numerators) {
            copy_numerators.add(nn);
        }

        Collections.sort(copy_numerators, Collections.reverseOrder());

        // map sorted (transformed) fractions to the original ones
        for (int sorted : copy_numerators) {
            // get index using array value
            index = new_numerators.indexOf(sorted);
            final_numerators.add(super.numerators.get(index));
            final_denominators.add(super.denominators.get(index));
        }
    }

}
