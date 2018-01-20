package arithmetic;

import java.util.ArrayList;
import java.util.List;

public class PrimeFactors {

    private final List<Integer> found_prime_factors;
    private final int find_my_factors;
    private String render_factors;
    private int i;

    public PrimeFactors(int val) {
        found_prime_factors = new ArrayList<>();
        find_my_factors = val;
        render_factors = "The prime factors of " + val + " are: \n";
        i = 2;
    }

    /**
    * Our function checks 'find_my_factors';
    * If it finds a factor, it records this factor,
    * then divides 'find_my_factors' by the found factor
    * and makes this the new 'find_my_factors'.
    * It continues recursively until all factors are found.
    * @param  - integer.
     */
    private int onlyPrimeFactors(int in_question) {
        int temp_limit;
        temp_limit = (int) Math.ceil(Math.sqrt(in_question));

        while (i <= temp_limit) {
            if (i != 1 && (in_question % i) == 0) { // avoid an infinite loop with the i != 1 check.
                found_prime_factors.add(i);
                return onlyPrimeFactors(in_question / i);
            }
            i++;
        }
        found_prime_factors.add(in_question);
        
        return 0;
    }
    
    /**
     * Renders the prime prime factors to screen.
     * @return - String value
     */
    public String getPrimeFactors() {
        onlyPrimeFactors(find_my_factors);
        
        //iterate through and retrieve members
        found_prime_factors.stream().forEach((factor) -> {
            render_factors += factor + " X ";
        });
        render_factors = render_factors.substring(0, render_factors.length()-3);
        
        return render_factors;
    }
    
}
