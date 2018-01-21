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
            fraction["numerator"] = 10;
            fraction["denominator"] = 3;

            Console.WriteLine("    Converting from Improper to Mixed the fraction:");
            // Print as fraction
            Console.WriteLine(String.Format("{0,55}", fraction["numerator"]));
            Console.WriteLine(String.Format("{0,55}", "-"));
            Console.WriteLine(String.Format("{0,55}", fraction["denominator"]));

            // use the MixedToImproper class
            ImproperToMixed imp_mix = new ImproperToMixed(fraction);
            fraction = imp_mix.doConvert();

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(String.Format("{0,52}", fraction["numerator"]));
            Console.WriteLine(String.Format("{0,48} {1} {2}", "Answer =   ", fraction["whole_number"], "-"));
            Console.WriteLine(String.Format("{0,52}", fraction["denominator"]));

        }
    }
}
