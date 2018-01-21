package miscellaneous;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Combination {

    public List<String> words;
    public int r; // min length of word
    protected List<String[]> comb_store;
    private int i;

    public Combination() {
    }

    // point of entry
    public List<String[]> possibleWordCombinations(List<String> candidates, int size) {
        words = candidates;
        r = size;
        comb_store = new ArrayList<>();
        i = 0;
        // check for conformity
        if (r <= 0 || r > words.size()) {
            comb_store = new ArrayList<>();
        } else if (r == 1) {
            for (; i < words.size(); i++) {
                comb_store.add(new String[]{words.get(i)});
            }
        } else {
            progressiveCombination();
        }
        return comb_store;
    }

    // do combinations for all 'words' element
    private void progressiveCombination() {
        //                  single member list
        repetitivePairing(Arrays.asList(words.get(i)), i + 1);
        if (i + r <= words.size()) {
            // move on to next degree
            i++;
            progressiveCombination();
        }
    }

    // do all possible combinations for 1st element of this array
    private void repetitivePairing(List<String> prefix, int position) {
        List<String>[] auxiliary_store = new List[words.size() - position];
        for (int j = 0; position < words.size(); position++, j++) {
            // check if desired -- r -- size will be realised
            if (j + i + r <= words.size()) {
                auxiliary_store[j] = new ArrayList<>();
                auxiliary_store[j].addAll(prefix);
                auxiliary_store[j].add(words.get(position));
                if (auxiliary_store[j].size() < r) {
                    // see to adding next word on
                    repetitivePairing(auxiliary_store[j], position + 1);
                } else {
                    comb_store.add(auxiliary_store[j].toArray(new String[0]));
                }
            }
        }
    }
}
