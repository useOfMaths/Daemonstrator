using System;
using System.Collections.Generic;
using System.Linq;

namespace Algebra_CS
{
    class SortFraction : AddFraction
    {
        public List<int> final_numerators;
        public List<int> final_denominators;

        public SortFraction(List<int> num, List<int> denom) : base(num, denom)
        {
            final_numerators = new List<int>();
            final_denominators = new List<int>();
        }

        public void sortAscending()
        {
            List<int> copy_numerators = new List<int>();
            int index;

            // STEPS 1, 2:
            canonizeFraction();

            foreach (int nn in new_numerators)
            {
                copy_numerators.Add(nn);
            }

            // STEP 3:
            // Sort array in ascending order order
            copy_numerators.Sort();

            // map sorted transformed fractions to their originals
            foreach (int sorted in copy_numerators)
            {
                index = Array.IndexOf<int>(new_numerators.ToArray<int>(), sorted);
                final_numerators.Add(numerators[index]);
                final_denominators.Add(denominators[index]);
            }
        }

        public void sortDescending()
        {
            List<int> copy_numerators = new List<int>();
            int index;

            // STEPS 1, 2:
            canonizeFraction();

            foreach (int nn in new_numerators)
            {
                copy_numerators.Add(nn);
            }

            // STEP 3:
            // Sort array in descending order order
            copy_numerators.Sort();
            copy_numerators.Reverse();

            // map sorted transformed fractions to their originals
            foreach (int sorted in copy_numerators)
            {
                index = Array.IndexOf<int>(new_numerators.ToArray<int>(), sorted);
                final_numerators.Add(numerators[index]);
                final_denominators.Add(denominators[index]);
            }
        }
    }
}
