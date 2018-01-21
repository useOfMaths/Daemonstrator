using System.Collections.Generic;

namespace Algebra_CS
{
    class AddFraction
    {
        protected List<int> numerators = new List<int>();
        protected List<int> denominators = new List<int>();
        protected List<int> new_numerators = new List<int>();
        protected int lcm;
        protected int answer = 0;

        public AddFraction(List<int> num, List<int> denom)
        {
            numerators = num;
            denominators = denom;
        }

        protected void canonizeFraction()
        {
            // STEP 1:
            LCM l_c_m = new LCM(denominators);
            lcm = l_c_m.getLCM();

            // STEP 2:
            for (int i = 0; i < denominators.Count; i++)
            {
                new_numerators.Add(lcm / denominators[i] * numerators[i]);
            }
        }

        public int[] doAdd()
        {
            canonizeFraction();

            // STEP 3:
            foreach (int n in new_numerators)
            {
                answer += n;
            }
            return new int[] { answer, lcm };
        }
    }
}
