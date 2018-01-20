using System.Collections.Generic;

namespace Arithmetic_CS
{
    class EvenNumbers
    {
        private int start; // Our starting point
        private int stop; // where we will stop
        private List<int> list_of_primes; // We will house our gathered prime numbers here.

        // Our constructor
        public EvenNumbers(int first, int last)
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
                if (start % 2 == 0)
                { // modulo(%) is explained later
                    list_of_primes.Add(start);
                }
                start = start + 1; // increase 'start' by 1
            }
            return list_of_primes;
        }
    }
}
