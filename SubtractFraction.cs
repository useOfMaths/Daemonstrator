using System.Collections.Generic;

namespace Algebra_CS
{
    class SubtractFraction : AddFraction
    {
        public SubtractFraction(List<int> num, List<int> denom) : base(num, denom)
        {
        }

        public int[] doSubtract()
        {
            // STEPS 1, 2:
            canonizeFraction();

            // STEP 3:
            answer = new_numerators[0];
            for (int i = 1; i < new_numerators.Count; i++)
            {
                answer -= new_numerators[i];
            }
            return new int[] { answer, lcm };
        }
    }
}
