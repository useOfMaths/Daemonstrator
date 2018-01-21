using System.Collections;

namespace Algebra_CS
{
    class MixedToImproper
    {
        private int numerator;
        private int denominator;
        private int whole_number;

        public MixedToImproper(Hashtable fraction)
        {
            whole_number = (int)fraction["whole_number"];
            numerator = (int)fraction["numerator"];
            denominator = (int)fraction["denominator"];
        }

        public int doConvert()
        {
            // STEP 1, 2:
            return (whole_number * denominator) + numerator;
        }
    }
}
