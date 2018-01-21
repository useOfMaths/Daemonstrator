package miscellaneous;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class Permutation extends Combination {

    private List<String[]> local_store;
    protected List<String[]> perm_store;
    private int index;

    public Permutation() {
        super();
    }

    // till the ground for shuffle to grind on
    public List<String[]> possibleWordPermutations(List<String> candidates, int size) {
        perm_store = new ArrayList<>();
        possibleWordCombinations(candidates, size);
        // illegal 'r' value
        if (comb_store.isEmpty() || r == 1) {
                perm_store = comb_store;
        } else {
            String[][] last_two = new String[2][2];
            for (int i = 0; i < comb_store.size(); i++) {
                index = r - 1;
                // copy up last two elements of 'comb_store.get(i)'
                last_two[0][0] = last_two[1][1] = comb_store.get(i)[index--];
                last_two[0][1] = last_two[1][0] = comb_store.get(i)[index--];
                local_store = new ArrayList<>();
                local_store.add(last_two[0]);
                local_store.add(last_two[1]);
                if (r > 2) {
                    shuffleWord(local_store, i);
                }
                perm_store.addAll(local_store);
            }
        }
        return perm_store;
    }

    private void shuffleWord(List<String[]> arg_store, int i) {
        local_store = new ArrayList<>();
        List<String> members;
        for (int j = 0; j < arg_store.size(); j++) {
            members = new ArrayList<>();
            members.addAll(Arrays.asList(arg_store.get(j)));
            // add 'index' 'comb_store.get(i)' element to this list of members
            members.add(comb_store.get(i)[index]);

            int shift_index = members.size();
            // shuffle this pack of words
            while (shift_index > 0) {
                // skip if already in store
                if (!local_store.contains(members.toArray(new String[0]))) {
                    local_store.add(members.toArray(new String[0]));
                }
                // interchange these two neighbours
                if (--shift_index > 0 && !members.get(shift_index).equals(members.get(shift_index - 1))) {
                    Collections.swap(members, shift_index - 1, shift_index);
                }
            }
        }
        // Are there any elements left? repeat if yes
        if (index-- > 0) {
            shuffleWord(local_store, i);
        }
    }
}