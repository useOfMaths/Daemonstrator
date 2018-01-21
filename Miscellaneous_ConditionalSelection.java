package miscellaneous;

import java.util.Arrays;
import java.util.List;

public class Miscellaneous {

    public static void main(String[] args) {
        String[] goods = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        ConditionalSelection choose = new ConditionalSelection();
        List<String[]> result = choose.limitedSelection(goods, 4,
             //      minimum number of occurrences           maximum number of occurrences
                new int[]{0, 0, 1, 0, 0, 1, 0, 0, 1, 0}, new int[]{4, 3, 2, 4, 3, 2, 4, 3, 2, 4});
        System.out.println(Arrays.toString(choose.words) + " conditioned selection " + choose.r + ":\n");
        for (String[] set : result) {
            System.out.println(Arrays.toString(set) + ";");
        }
        System.out.println("\nNumber of ways is " + result.size() + ".");
    }

}
