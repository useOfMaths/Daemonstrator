package arithmetic;

import java.util.ArrayList;
import java.util.List;

public class Arithmetic {

    public static void main(String[] args) {
        System.out.println("Welcome to our demonstration sequels");
        System.out.println("Hope you enjoy (and follow) the lessons.");
        System.out.println("");

        /*
        * Find LCM.
         */
        String render_result = "The LCM of ";
        LCM lcm;
        List<Integer> group;

        group = new ArrayList<>();
        group.add(40);
        group.add(50);
        group.add(60);

        for (int number : group) {
            render_result += number + "; ";
        }
        render_result += "is:  ";

        lcm = new LCM(group);
        System.out.println(render_result + lcm.getLCM());
    }
}
