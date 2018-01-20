using System.Collections.Generic;

namespace Arithmetic_CS
{
    class HCF
    {
        private int[] set_of_numbers;
        private List<int> common_factors = new List<int>(); // factors common to our set_of_numbers

        private int index; // index into array common_factors
        private bool all_round_factor; // variable to keep state
        private int calc_result; // helps calculate H.C.F.

        public HCF(List<int> group)
        {
            set_of_numbers = new int[group.Count];
            index = 0;

            // STEP 1:
            group.Sort();

            //iterate through and retrieve members
            foreach (int number in group)
            {
                set_of_numbers[index] = number;
                index++;
            }

            index = 2;
            all_round_factor = false;
            calc_result = 1;
        }

        /**
         * Our function checks 'set_of_numbers'; If it finds a factor common to
         * all for it, it records this factor; then divides 'set_of_numbers' by the
         * common factor found and makes this the new 'set_of_numbers'. It
         * continues recursively until all common factors are found.
         */
        private int findHCFFactors()
        {
            while (index <= set_of_numbers[0])
            {
                // Check for factors common to every member of 'set_of_numbers'
                all_round_factor = true;
                // STEP 2:
                for (int j = 0; j < set_of_numbers.Length; j++)
                {
                    if (!(all_round_factor == true && set_of_numbers[j] % index == 0))
                    {
                        all_round_factor = false;
                    }
                }
                // STEP 3:
                // Divide every member of 'set_of_numbers by each common factor
                if (all_round_factor == true)
                {
                    for (int j = 0; j < set_of_numbers.Length; j++)
                    {
                        set_of_numbers[j] /= index;
                    }
                    common_factors.Add(index);
                    // STEP 4:
                    return findHCFFactors();
                }
                index++;
            }

            return 0;
        }

        /**
         * Just calls out and collects the prepared factors.
         * @return - string value
         */
        public int getHCF()
        {
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
