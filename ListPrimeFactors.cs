using System;
using System.Collections.Generic;

namespace Arithmetic_CS
{
    class ListPrimeFactors
    {
        private List<int> found_prime_factors;
        private int find_my_factors;
        private int index;

        public ListPrimeFactors(int val)
        {
            found_prime_factors = new List<int>();
            find_my_factors = val;
            // STEP 1:
            index = 2;
        }

        /**
        * Our function checks 'find_my_factors';
        * If it finds a factor, it records this factor,
        * then divides 'find_my_factors' by the found factor
        * and makes this the new 'find_my_factors'.
        * It continues recursively until all factors are found.
        * @param  - integer.
         */
        private int onlyPrimeFactors(int in_question)
        {
            int temp_limit;
            temp_limit = (int)Math.Ceiling(Math.Sqrt(in_question));

            while (index <= temp_limit)
            {
                // STEP 4:
                if (index != 1 && (in_question % index) == 0)
                { // avoid an infinite loop with the i != 1 check.
                    found_prime_factors.Add(index);
                    // STEP 2, 3:
                    return onlyPrimeFactors(in_question / index);
                }
                index++;
            }
            found_prime_factors.Add(in_question);

            return 0;
        }

        /**
         * Renders the prime factors to screen.
         * @return - a list
         */
        public List<int> getPrimeFactors()
        {
            onlyPrimeFactors(find_my_factors);
            return found_prime_factors;
        }
    }
}
