using System.Collections;

namespace Algebra_CS
{
    class ImproperToMixed
    {
        private int numerator;
        private int denominator;
        private int whole_number;
        private int new_numerator;

        public ImproperToMixed(Hashtable fraction)
        {
            numerator = (int)fraction["numerator"];
            denominator = (int)fraction["denominator"];
        }

        public Hashtable doConvert()
        {
            int dividend; // Highest multiple of denominator less than numerator
                          // STEP 1:
            for (dividend = numerator - 1; dividend > 1; dividend--)
            {
                if ((dividend % denominator) == 0)
                {
                    // STEP 2:
                    new_numerator = numerator - dividend;
                    // STEP 3:
                    whole_number = dividend / denominator;
                    break;
                }
            }

            Hashtable send_back = new Hashtable();
            send_back.Add("whole_number", whole_number);
            send_back.Add("numerator", new_numerator);
            send_back.Add("denominator", denominator);
            return send_back;

        }
    }
}
