package algebra;

import java.util.List;

public class SubtractFraction extends AddFraction {
    
    public SubtractFraction(List<Integer> num, List<Integer> denom){
        super(num, denom);
    }
    
    public int[] doSubtract() {
        canonizeFraction();

        answer = new_numerators.get(0);
        for (int i=1; i< new_numerators.size(); i++) {
            answer -= new_numerators.get(i);
        }
        return new int[]{answer, lcm};
    }
    
}
