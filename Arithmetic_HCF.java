package arithmetic;

import java.util.ArrayList;
import java.util.List;

public class Arithmetic {

    public static void main(String[] args) {
        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /*
        * Find HCF.
         */
        String render_result = "The HCF of ";
        HCF hcf;
        List<Integer> set;

        set = new ArrayList<>();
        set.add(30);
        set.add(48);
        set.add(54);

        for (int number : set) {
            render_result += number + "; ";
        }
        render_result += "is:  ";

        hcf = new HCF(set);
        System.out.println(render_result + hcf.getHCF());
    }

}
