using System.Collections.Generic;

namespace Arithmetic_CS
{
    class LCM
    {
        private List<int> set_of_numbers = new List<int>();
        private List<int> arg_copy = new List<int>(); // arrays are passed by reference; make a copy.
        private List<int> all_factors = new List<int>(); // factors common to our set_of_numbers

        private int index; // index into array common_factors
        private bool state_check; // variable to keep state
        private int calc_result;

        public LCM(List<int> group)
        {
            //iterate through and retrieve members
            foreach (int number in group)
            {
                set_of_numbers.Add(number);
                arg_copy.Add(number);
            }

            set_of_numbers.Sort();
            set_of_numbers.Reverse();

            state_check = false;
            calc_result = 1;
        }

        /**
         * Our function checks 'set_of_numbers'; If it finds a factor common to all
         * for it, it records this factor; then divides 'set_of_numbers' by the
         * common factor found and makes this the new 'set_of_numbers'. It continues
         * recursively until all common factors are found.
         *
         */
        private int findLCMFactors()
        {
            for (int i = 0; i < set_of_numbers.Count; i++)
            {
                arg_copy[i] = set_of_numbers[i];
            }
            // STEP 1:
            arg_copy.Sort();
            arg_copy.Reverse();

            while (index <= arg_copy[0])
            {
                state_check = false;
                for (int j = 0; j < set_of_numbers.Count; j++)
                {
                    if (set_of_numbers[j] != 1 && (set_of_numbers[j] % index) == 0)
                    {
                        // STEP 3:
                        set_of_numbers[j] /= index;
                        if (state_check == false)
                        {
                            all_factors.Add(index);
                        }
                        state_check = true;
                    }
                }
                // STEP 4:
                if (state_check == true)
                {
                    return findLCMFactors();
                }
                index++;
            }

            return 0;
        }

        /**
         * Just calls out and collects the prepared factors.
         * @return - int value;
         */
        public int getLCM()
        {
            // STEP 2:
            index = 2;
            findLCMFactors();

            //iterate through and retrieve members
            foreach (int factor in all_factors)
            {
                calc_result *= factor;
            }

            return calc_result;
        }
    }
}
