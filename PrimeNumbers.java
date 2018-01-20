package arithmetic;

import java.util.ArrayList; // We are using an array list.
import java.util.List;

public class PrimeNumbers {

    private final List<Integer> list_of_primes; // We will house our gathered prime numbers here.
    private final int start; // Where to start.
    private final int stop; // Where to stop.
    private int progress; // progress report
    private int index; // index into array list_of_primes
    private double square_root; // Our loop range for speed enhancement
    private boolean do_next_iteration;

    public PrimeNumbers(int first, int last) {
        start = first;
        stop = last;
        // STEP 1:
        progress = 9;

        list_of_primes = new ArrayList<>();
        list_of_primes.add(2);
        list_of_primes.add(3);
        list_of_primes.add(5);
        list_of_primes.add(7);

        square_root = 0;
    }

    /**
     * Garners the prime numbers between the requested range.
     *
     * @return String value
     */
    public String getPrimes() {
        // STEP 2:
        for (; progress < stop; progress += 2) {
            
            do_next_iteration = false; // a flag

            // STEPS 3, 4:
            // Check through already accumulated prime numbers
            // to see if any is a factor of "progress".
            square_root = (int) Math.ceil(Math.sqrt(progress));

            index = 0;
            for (; list_of_primes.get(index) <= square_root; index++) {
                if ((progress % list_of_primes.get(index)) == 0) {
                    do_next_iteration = true;
                    break;
                }
            }
            if (do_next_iteration) {
                continue;
            }

            // if all checks are scaled,then "progress" is our guy.
            list_of_primes.add(progress);
        }

        // Display result.
        return ("The set of prime numbers between " + start + " and " + stop
                + " are: \n" + list_of_primes);
    }
}
