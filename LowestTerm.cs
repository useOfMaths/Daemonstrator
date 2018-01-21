using System.Collections;

namespace Algebra_CS
{
    class LowestTerm
    {
        protected int numerator;
        protected int denominator;
        protected int trial_factor;

        public LowestTerm(Hashtable fraction)
        {
            numerator = (int)fraction["numerator"];
            denominator = (int)fraction["denominator"];

            if (numerator < denominator)
            {
                trial_factor = numerator;
            }
            else
            {
                trial_factor = numerator;
            }
        }

        public Hashtable reduceFraction()
        {
            // We are counting down to test for mutual factors 
            while (trial_factor > 1)
            {
                // do we have a factor
                if ((numerator % trial_factor) == 0)
                {
                    // is this factor mutual?
                    if ((denominator % trial_factor) == 0)
                    {
                        // where we have a mutual factor
                        numerator /= trial_factor;
                        denominator /= trial_factor;
                        continue; // continue with next iteration, repeating the current value of trial_factor
                    }
                }
                trial_factor--;
            }

            Hashtable send_back = new Hashtable();
            send_back.Add("numerator", numerator);
            send_back.Add("denominator", denominator);
            return send_back;
        }
    }
}
