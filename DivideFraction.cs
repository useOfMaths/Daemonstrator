using System.Collections.Generic;

namespace Algebra_CS
{
    class DivideFraction : MultiplyFraction
    {
        public DivideFraction(List<int> num, List<int> denom) : base(num, denom)
        {
        }

        public int[] doDivide()
        {
            int temp;
            // Invert every other fraction but the first
            for (int i = 1; i < numerators.Count; i++)
            {
                temp = numerators[i];
                numerators[i] = denominators[i];
                denominators[i] = temp;
            }
            return doMultiply();
        }
    }
}
