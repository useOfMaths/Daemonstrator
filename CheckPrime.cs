using System;

namespace Arithmetic_CS
{
    class CheckPrime
    {
        private int prime_suspect; // We suspect that this number is prime
        private double square_root; // this variable is a helping one.

        public CheckPrime(int val)
        {
            // let's see whether prime_suspect is at a premium(is a prime).
            prime_suspect = val;
            square_root = Math.Sqrt(prime_suspect); // Get square root
        }

        /**
         * Does the actual evaluation to see if our number is prime.
         * @return boolean value
         */
        public bool verifyPrime()
        {
            /* Loop through searching for factors. */
            for (int i = 2; i < prime_suspect; i++)
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
