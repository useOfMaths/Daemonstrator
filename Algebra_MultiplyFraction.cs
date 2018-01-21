using System;
using System.Collections;
using System.Collections.Generic;

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
            * Multiplying fractions
             */
            List<int> numerators = new List<int>();
            numerators.Add(16);
            numerators.Add(20);
            numerators.Add(27);
            numerators.Add(20);

            List<int> denominators = new List<int>();
            denominators.Add(9);
            denominators.Add(9);
            denominators.Add(640);
            denominators.Add(7);

            Console.WriteLine("    Solving:");
            // Print as fraction
            foreach (int n in numerators)
            {
                Console.Write(String.Format("{0,13}", n));
            }
            Console.Write(Environment.NewLine + String.Format("{0,12}", " "));
            for (int i = 0; i < numerators.Count - 1; i++)
            {
                Console.Write(String.Format("{0}", "-     X      "));
            }
            Console.WriteLine(String.Format("{0,1}", "-"));
            foreach (int d in denominators)
            {
                Console.Write(String.Format("{0,13}", d));
            }
            Console.WriteLine();

            // use the MultiplyFraction class
            MultiplyFraction mul_fract = new MultiplyFraction(numerators, denominators);
            int[] solution = mul_fract.doMultiply();

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(String.Format("{0,25}", solution[0]));
            Console.WriteLine(String.Format("{0,25}", "Answer   =   -"));
            Console.WriteLine(String.Format("{0,25}", solution[1]));

        }
    }
}
