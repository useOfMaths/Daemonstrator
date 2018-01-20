using System.Collections.Generic;

namespace Arithmetic_CS
{
    class OddNumbers
    {
        private int start; // Our starting point
        private int stop; // where we will stop
        private List<int> list_of_primes; // We will house our gathered prime numbers here.

        // Our constructor
        public OddNumbers(int first, int last)
        {
            start = first;
            stop = last;
            list_of_primes = new List<int>();
        }

        public List<int> prepResult()
        {
            /*
            * Loop from start to stop and rip out even numbers;
             */
            while (start <= stop)
            {
                if (start % 2 != 0)
                {
                    list_of_primes.Add(start);
                }
                start++; // increase 'start' by 1
            }
            return list_of_primes;
        }
    }
}
