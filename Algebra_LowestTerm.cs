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
            fraction["numerator"] = 16;
            fraction["denominator"] = 640;

            Console.WriteLine("    To reduce to lowest term, simplifying:");
            // Print as fraction
            Console.WriteLine(String.Format("{0,45}", fraction["numerator"]));
            Console.WriteLine(String.Format("{0,45}", "-"));
            Console.WriteLine(String.Format("{0,45}", fraction["denominator"]));

            // use the MixedToImproper class
            LowestTerm red_fract = new LowestTerm(fraction);
            fraction = red_fract.reduceFraction();

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(String.Format("{0,46}", fraction["numerator"]));
            Console.WriteLine(String.Format("{0,46}", "Answer =    -"));
            Console.WriteLine(String.Format("{0,46}", fraction["denominator"]));

        }
    }
}
