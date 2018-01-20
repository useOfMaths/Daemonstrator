package arithmetic;

import java.util.ArrayList;
import java.util.List;
import java.util.Comparator;

public class HCF {

    private final int[] set_of_numbers;
    private final List<Integer> common_factors = new ArrayList<>(); // factors common to our set_of_numbers

    private int index; // index into array common_factors
    private boolean all_round_factor; // variable to keep state
    private int calc_result; // helps calculate HCF
    private Comparator c; // object for sorting arrays

    public HCF(List<Integer> group) {
        set_of_numbers = new int[group.size()];
        index = 0;
        
        group.sort(c);
        
        //iterate through and retrieve members
        for (int number : group) {
            set_of_numbers[index] = number;
            index++;
        }
        
        index = 2;
        all_round_factor = false;
    }

    /**
     * Our function checks 'set_of_numbers'; If it finds a factor common to
     * all for it, it records this factor; then divides 'set_of_numbers' by the
     * common factor found and makes this the new 'set_of_numbers'. It
     * continues recursively until all common factors are found.
     */
    private int findHCFFactors() {
        while (index <= set_of_numbers[0]) {

            // Check for factors common to every member of 'set_of_numbers'
            all_round_factor = true;
            for (int j = 0; j < set_of_numbers.length; j++) {
                if (!(all_round_factor == true && (set_of_numbers[j] % index) == 0)) {
                    all_round_factor = false;
                }
            }
            // Divide every member of 'set_of_numbers by each common factor
            if (all_round_factor == true) {
                for (int j = 0; j < set_of_numbers.length; j++) {
                    set_of_numbers[j] /= index;
                }
                common_factors.add(index);
                return findHCFFactors();
            }
            index++;
        }

        return 0;
    }
    
    /**
     * Just calls out and collects the prepared factors.
     * @return - string value
     */
    public int getHCF() {
        findHCFFactors();
        
        //iterate through and retrieve members
        calc_result = 1;
        common_factors.stream().forEach((factor) -> {
            calc_result *= factor;
        });
        
        return calc_result;
    }
}