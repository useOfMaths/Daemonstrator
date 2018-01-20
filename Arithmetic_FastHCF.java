package arithmetic;

import java.util.ArrayList;
import java.util.List;

public class Arithmetic {

    public static void main(String[] args) {
        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        List<Integer> set;
        set = new ArrayList<>();
        set.add(30);
        set.add(48);
        set.add(54);

        String render_result = "The HCF of ";
        for (int number : set) {
            render_result += number + "; ";
        }
        render_result += "is:  ";

        //Use fast copy
        FastHCF h_c_f;
        h_c_f = new FastHCF(set);
        System.out.println(render_result + h_c_f.getHCF());
    }

}
