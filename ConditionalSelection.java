package miscellaneous;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class ConditionalSelection extends Selection {

    private List<String[]> final_elements;

    public ConditionalSelection() {
        super();
    }

    public List<String[]> limitedSelection(String[] candidates, int size, int[] minimum, int[] maximum) {
        final_elements = new ArrayList<>();
        groupSelection(candidates, size);
        List<String> members;
        for (int i = 0; i < complete_group.size(); i++) {
            members = new ArrayList<>();
            members.addAll(Arrays.asList(complete_group.get(i)));
            boolean state = false;
            for (int j = 0; j < words.length; j++) {
                // get 'words[j]' frequency/count in group
                int count = Collections.frequency(members, words[j]);
                if (count >= minimum[j] && count <= maximum[j]) {
                    state = true;
                } else {
                    state = false;
                    break;
                }
            }
            // skip if already in net
            if (state) {
                final_elements.add(complete_group.get(i));
            }
        }
        return final_elements;
    }
}
