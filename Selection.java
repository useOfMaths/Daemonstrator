package miscellaneous;

import java.util.ArrayList;
import java.util.List;

public class Selection {

    public String[] words;
    public int r; // min length of word
    protected List<String[]> complete_group;
    private int i;

    public Selection() {
    }

    public List<String[]> groupSelection(String[] candidates, int size) {
        words = candidates;
        r = size;
        complete_group = new ArrayList<>();
        i = 0;
        recursiveFillUp(new ArrayList<>());

        return complete_group;
    }

// pick elements recursively
    protected void recursiveFillUp(List<String> temp) {
        List<String>[] picked_elements = new List[words.length];
        int j = i;
        while (j < words.length) {
            picked_elements[j] = new ArrayList<>();
            picked_elements[j].addAll(temp);
            picked_elements[j].add(words[j]);
            // recoil factor
            if (i >= words.length) {
                i = j;
            }
            // satisfied yet?
            if (picked_elements[j].size() == r) {
                complete_group.add(picked_elements[j].toArray(new String[0]));
            } else if (picked_elements[j].size() < r) {
                recursiveFillUp(picked_elements[j]);
            }
            j++;
        }
        if (picked_elements[--j] != null && picked_elements[j].size() == r) {
            i++; // keep recoil factor straightened out
        }
    }
}
