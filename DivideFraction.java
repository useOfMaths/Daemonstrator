package algebra;

import java.util.List;

public class DivideFraction extends MultiplyFraction {
    
    public DivideFraction(List<Integer> num, List<Integer> denom){
        super(num, denom);
    }
    
    public int[] doDivide(){
        int temp;
        // Invert every other fraction but the first
        for(int i=1; i<numerators.size(); i++){
            temp = numerators.get(i);
            numerators.set(i, denominators.get(i));
            denominators.set(i, temp);
        }
        return doMultiply();
    }
}
