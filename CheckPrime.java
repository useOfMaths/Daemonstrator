package arithmetic;

public class CheckPrime {

    private final int prime_suspect; // We suspect that this number is prime
    private final double square_root; // this variable is a helping one.
    private final int test_range; // range for minimal looping

    public CheckPrime(int val) {
        // let's see whether prime_suspect is at a premium(is a prime).
        prime_suspect = val;
        square_root = Math.sqrt(prime_suspect); // Get square root
        test_range = (int) Math.ceil(square_root); // Extract an absolute value
    }

    /**
     * Does the actual evaluation to see if our number is prime.
     */
    public String verifyPrime() {
        /* Loop through searching for factors. */
        for (int i = 2; i < prime_suspect; i++) {
            if ((prime_suspect % i) == 0) {
                return (prime_suspect + " is not a prime number.\n"
                        + "At least " + i + " is a factor of " + prime_suspect);
            }
        }

        // If no factor is found:
        return (prime_suspect + " is a prime number.");
    }

}
