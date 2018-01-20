package algebra;

import java.util.ArrayList;
import java.util.List;

public class AddFraction {

    protected final List<Integer> numerators;
    protected final List<Integer> denominators;
    protected List<Integer> new_numerators;
    protected int lcm;
    protected int answer = 0;

    public AddFraction(List<Integer> num, List<Integer> denom) {
        numerators = num;
        denominators = denom;
        new_numerators = new ArrayList<>();
    }

    protected void canonizeFraction() {
        LCM l_c_m = new LCM(denominators);
        lcm = l_c_m.getLCM();

        for (int i = 0; i < denominators.size(); i++) {
            new_numerators.add(lcm / denominators.get(i) * numerators.get(i));
        }
    }

    public int[] doAdd() {
        canonizeFraction();

        for (int n : new_numerators) {
            answer += n;
        }
        return new int[]{answer, lcm};
    }
}
