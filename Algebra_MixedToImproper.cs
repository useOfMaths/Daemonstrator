using System;
using System.Collections;

namespace Algebra_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our demonstration sequels");
            Console.WriteLine("Hope you enjoy (and follow) the lessons.");
            Console.WriteLine("\r\n");

            /*
            * Convert fractions from Mixed to Improper
             */
            Hashtable fraction = new Hashtable();
            fraction["whole_number"] = 3;
            fraction["numerator"] = 1;
            fraction["denominator"] = 3;

            Console.WriteLine("    Converting from Mixed to Improper the fraction:");
            // Print as fraction
            Console.WriteLine(String.Format("{0,55}", fraction["numerator"]));
            Console.WriteLine(String.Format("{0,53} {1}", fraction["whole_number"], "-"));
            Console.WriteLine(String.Format("{0,55}", fraction["denominator"]));

            // use the MixedToImproper class
            MixedToImproper mix_imp = new MixedToImproper(fraction);
            fraction["numerator"] = mix_imp.doConvert();

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(String.Format("{0,52}", fraction["numerator"]));
            Console.WriteLine(String.Format("{0,52}", "Answer =      -"));
            Console.WriteLine(String.Format("{0,52}", fraction["denominator"]));
        }
    }
}
