package miscellaneous;

import java.util.Arrays;
import java.util.List;

public class Miscellaneous {

    public static void main(String[] args) {
        String[] goods = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        Selection pick = new Selection();
        List<String[]> result = pick.groupSelection(goods, 3);
        System.out.println(Arrays.toString(pick.words) + " selection " + pick.r + ":\n");
        for (String[] set : result) {
            System.out.println(Arrays.toString(set) + ";");
        }
        System.out.println("\nNumber of ways is " + result.size() + ".");
    }

}
