using System;
using System.Collections.Generic;

namespace Arithmetic_CS
{
    class ListFactors
    {
        private List<int> found_factors;
        private int find_my_factors;
        private int sqrt_range; // Use this range for our loop

        public ListFactors(int candidate)
        {
            found_factors = new List<int>();
            find_my_factors = candidate;
            sqrt_range = (int)Math.Ceiling(Math.Sqrt(find_my_factors));
        }

        /**
         * Does the main job of finding the requested factors.
         * @return - array list of integers
         */
        public List<int> doBusiness()
        {
            /* Loop through 1 to 'find_my_factors' and test for divisibility. */
            for (int i = 1; i < sqrt_range; i++)
            {
                if ((find_my_factors % i) == 0)
                {
                    found_factors.Add(i);
                    /* Get the complementing factor by dividing 'find_my_factor' by variable i. */
                    found_factors.Add(find_my_factors / i);
                }
            }

            // Sort the array in ascending order; Not entirely necessary.
            found_factors.Sort();

            return found_factors;
        }
    }
}
