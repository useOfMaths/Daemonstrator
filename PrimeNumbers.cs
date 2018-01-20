using System;
using System.Collections.Generic;

namespace Arithmetic_CS
{
    class PrimeNumbers
    {
        private List<int> list_of_primes; // We will house our gathered prime numbers here.
        private int start; // Where to start.
        private int stop; // Where to stop.
        private int progress; // progress report
        private int index; // index into array list_of_primes
        private double square_root; // Our loop range for speed enhancement
        private bool do_next_iteration;

        public PrimeNumbers(int first, int last)
        {
            start = first;
            stop = last;
            // STEP 1:
            progress = 9;

            list_of_primes = new List<int>();
            list_of_primes.Add(2);
            list_of_primes.Add(3);
            list_of_primes.Add(5);
            list_of_primes.Add(7);

            square_root = 0;
        }

        /**
         * Garners the prime numbers between the requested range.
         *
         * @return String value
         */
        public List<int> getPrimes()
        {
            // STEP 2:
            for (; progress < stop; progress += 2)
            {
                do_next_iteration = false; // a flag

                // STEPS 3, 4:
                // Check through already accumulated prime numbers
                // to see if any is a factor of "progress".
                square_root = (int)Math.Ceiling(Math.Sqrt(progress));

                index = 0;
                for (; list_of_primes[index] <= square_root; index++)
                {
                    if ((progress % list_of_primes[index]) == 0)
                    {
                        do_next_iteration = true;
                        break;
                    }
                }
                if (do_next_iteration)
                {
                    continue;
                }

                // if all checks are scaled,then "progress" is our guy.
                list_of_primes.Add(progress);
            }

            // Display result.
            return list_of_primes;
        }
    }
}
