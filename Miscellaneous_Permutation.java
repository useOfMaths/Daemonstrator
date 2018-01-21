package miscellaneous;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Miscellaneous {

    public static void main(String[] args) {
        List<String> goods = new ArrayList<>();
        goods.add("Eno");
        goods.add("Chidi");
        goods.add("Olu");
        goods.add("Ahmed");
        goods.add("Osas");
        goods.add("Gbeda");
        Permutation perm = new Permutation();
        List<String[]> result = perm.possibleWordPermutations(goods, 3);
        System.out.println(perm.words + " permutation " + perm.r + ":\n");
        for (String[] set : result) {
            System.out.println(Arrays.toString(set) + ";");
        }
        System.out.println("\nNumber of ways is " + result.size() + ".");
    }

}