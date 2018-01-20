package arithmetic;

import java.util.ArrayList;
import java.util.List;
import java.util.Comparator;

public class FastHCF {
    
    private final int[] set_of_numbers;
    private final int[] arg_copy; // Java passes arrays by reference; make a copy.
    private final List<Integer> common_factors = new ArrayList<>(); // factors common to our set_of_numbers
    private final List<Integer> min_prime_factors = new ArrayList<>();

    private int index; // index into array common_factors
    private boolean all_round_factor; // intiable to keep state
    private int calc_result;
    private Comparator c;
    
    public FastHCF(List<Integer> group) {
        set_of_numbers = new int[group.size()];
        arg_copy = new int[group.size()];
        index = 0;
        
        group.sort(c);
        //iterate through and retrieve members
        for (int number : group) {
            set_of_numbers[index] = number;
            arg_copy[index] = number;
            index++;
        }
        
        all_round_factor = false;
        calc_result = 1;
    }
    
    private int onlyPrimeFactors(int in_question) {
        int temp_limit;
        temp_limit = (int) Math.ceil(Math.sqrt(in_question));

        while (index <= temp_limit) {
            if ((in_question % index) == 0) { // avoid an infinite loop with the i != 1 check.
                min_prime_factors.add(index);
                return onlyPrimeFactors(in_question / index);
            }
            index++;
        }
        min_prime_factors.add(in_question);
        
        return 0;
    }
    
    /**
     * This function searches for mutual factors using an already computed
     * list of factors(for the smallest member of 'set_of_numbers').
     * @return - Nil
     */
    private int findHCFFactors() {
        while (index < min_prime_factors.size()) {

            all_round_factor = true;
            for (int j = 0; j < arg_copy.length; j++) {
                if (!(all_round_factor == true && 
                (arg_copy[j] % min_prime_factors.get(index)) == 0))
                {
                    all_round_factor = false;
                }
            }
            if (all_round_factor == true) {
                for (int j = 0; j < arg_copy.length; j++) {
                    arg_copy[j] /= min_prime_factors.get(index);
                }
                common_factors.add(min_prime_factors.get(index));
            }
            index++;
        }

        return 0;
    }
    
    /**
     * Just calls out and collects the prepared factors.
     * @return - String value
     */
    public int getHCF() {
        index = 2;
        onlyPrimeFactors(set_of_numbers[0]);
        
        index = 0;
        findHCFFactors();
        
        //iterate through and retrieve members
        common_factors.stream().forEach((factor) -> {
            calc_result *= factor;
        });
        
        return calc_result;        
    }
}
