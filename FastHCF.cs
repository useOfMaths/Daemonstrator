using System;
using System.Collections.Generic;

namespace Arithmetic_CS
{
    class FastHCF
    {
        private int[] set_of_numbers;
        private int[] arg_copy; // Java passes arrays by reference; make a copy.
        private List<int> common_factors = new List<int>(); // factors common to our set_of_numbers
        private List<int> min_prime_factors = new List<int>();

        private int index; // index into array common_factors
        private bool all_round_factor; // intiable to keep state
        private int calc_result;

        public FastHCF(List<int> group)
        {
            set_of_numbers = new int[group.Count];
            arg_copy = new int[group.Count];
            index = 0;

            // STEP 1:
            group.Sort();
            //iterate through and retrieve members
            foreach (int number in group)
            {
                set_of_numbers[index] = number;
                arg_copy[index] = number;
                index++;
            }

            all_round_factor = false;
            calc_result = 1;
        }

        // STEP 2:
        /*
         * Compiles only the factors of the smallest member of 'group_of_numbers'
         */
        private int onlyPrimeFactors(int in_question)
        {
            int temp_limit;
            temp_limit = (int)Math.Ceiling(Math.Sqrt(in_question));

            while (index <= temp_limit)
            {
                if ((in_question % index) == 0)
                {
                    min_prime_factors.Add(index);
                    return onlyPrimeFactors(in_question / index);
                }
                index++;
            }
            min_prime_factors.Add(in_question);

            return 0;
        }

        /**
         * This function searches for mutual factors using an already computed list
         * of factors(for the smallest member of 'set_of_numbers').
         *
         * @return - Nil
         */
        private int findHCFFactors()
        {
            while (index < min_prime_factors.Count)
            {
                all_round_factor = true;
                // STEP 3:
                for (int j = 0; j < arg_copy.Length; j++)
                {
                    if (!(all_round_factor == true
                            && (arg_copy[j] % min_prime_factors[index]) == 0))
                    {
                        all_round_factor = false;
                    }
                }

                // STEP 4:
                if (all_round_factor == true)
                {
                    for (int j = 0; j < arg_copy.Length; j++)
                    {
                        arg_copy[j] /= min_prime_factors[index];
                    }
                    common_factors.Add(min_prime_factors[index]);
                }
                index++;
            }

            return 0;
        }

        /**
         * Just calls out and collects the prepared factors.
         *
         * @return - String value
         */
        public int getHCF()
        {
            index = 2;
            onlyPrimeFactors(set_of_numbers[0]);

            index = 0;
            findHCFFactors();

            //iterate through and retrieve members
            foreach (int factor in common_factors)
            {
                calc_result *= factor;
            }

            return calc_result;
        }
    }
}
