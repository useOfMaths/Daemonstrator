package arithmetic;

public class CheckPrimeFast {

    private final int prime_suspect; // We suspect that this number is prime
    private final double square_root; // this variable is a helping one.
    private final int test_range; // range for minimal looping

    public CheckPrimeFast(int val) {
        // let's see whether prime_suspect is at a premium(is a prime).
        prime_suspect = val;
        square_root = Math.sqrt(prime_suspect); // Get square root
        test_range = (int)Math.ceil(square_root); // Extract an absolute value
    }

    /**
     * Verifies primeness quickly.
     * @return String value
     */
    public String verifyPrimeFast() {
        /* Loop through a small range searching for factors. */
        for (int i = 2; i < test_range; i++) {
            if ((prime_suspect % i) == 0) {
                return (prime_suspect + " is not a prime number.\n"
                        + "At least " + i + " is a factor of " + prime_suspect);
            }
        }

        // If no factor is found:
        return (prime_suspect + " is a prime number.");
    }

}
