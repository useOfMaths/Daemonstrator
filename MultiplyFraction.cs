using System.Collections.Generic;

namespace Algebra_CS
{
    class MultiplyFraction
    {
        protected List<int> numerators = new List<int>();
        protected List<int> denominators = new List<int>();
        protected int[] answer = { 1, 1 };
        protected int n_index, d_index;
        protected int trial_factor;
        protected bool mutual_factor;

        public MultiplyFraction(List<int> num, List<int> denom)
        {
            numerators = num;
            denominators = denom;

            trial_factor = 0;
            n_index = 0;
            d_index = 0;

            foreach (int n in numerators)
            {
                if (n > trial_factor)
                {
                    trial_factor = n;
                }
            }
            foreach (int d in denominators)
            {
                if (d > trial_factor)
                {
                    trial_factor = d;
                }
            }
        }


        public int[] doMultiply()
        {
            // STEP 3:
            // We are counting down to test for mutual factors 
            while (trial_factor > 1)
            {
                // STEP 1:
                // iterate through numerators and check for factors
                while (n_index < numerators.Count)
                {
                    mutual_factor = false;
                    if ((numerators[n_index] % trial_factor) == 0)
                    { // do we have a factor
                      // iterate through denominators and check for factors
                        while (d_index < denominators.Count)
                        {
                            if ((denominators[d_index] % trial_factor) == 0)
                            { // is this factor mutual?
                                mutual_factor = true;
                                break; // stop as soon as we find a mutual factor so preserve the corresponding index
                            }
                            d_index++;
                        }
                        break; // stop as soon as we find a mutual factor so as  preserve the corresponding index
                    }
                    n_index++;
                }
                // STEP 2:
                // where we have a mutual factor
                if (mutual_factor)
                {
                    numerators[n_index] = numerators[n_index] / trial_factor;
                    denominators[d_index] = denominators[d_index] / trial_factor;
                    continue; // continue with next iteration repeating the current value of trial_factor
                }
                n_index = 0;
                d_index = 0;
                trial_factor--;
            }

            for (int i = 0; i < numerators.Count; i++)
            {
                answer[0] *= numerators[i];
                answer[1] *= denominators[i];
            }

            return answer;
        }
    }
}
