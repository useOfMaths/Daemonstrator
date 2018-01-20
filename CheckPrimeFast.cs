using System;

namespace Arithmetic_CS
{
    class CheckPrimeFast
    {
        private int prime_suspect; // We suspect that this number is prime
        private double square_root; // this variable is a helping one.
        private int test_range; // range for minimal looping

        public CheckPrimeFast(int val)
        {
            // let's see whether prime_suspect is at a premium(is a prime).
            prime_suspect = val;
            square_root = Math.Sqrt(prime_suspect); // Get square root
            test_range = (int)Math.Ceiling(square_root); // Extract an absolute value
        }

        /**
         * Does the actual evaluation to see if our number is prime.
         * @return boolean value
         */
        public bool verifyPrime()
        {
            /* Loop through searching for factors. */
            for (int i = 2; i < test_range; i++)
            {
                if ((prime_suspect % i) == 0)
                {
                    return false;
                }
            }

            // If no factor is found:
            return true;
        }
    }
}
