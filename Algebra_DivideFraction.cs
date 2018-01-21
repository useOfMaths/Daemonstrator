using System;
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
            * Dividing fractions
             */
            List<int> numerators = new List<int>();
            numerators.Add(16);
            numerators.Add(9);
            numerators.Add(640);
            numerators.Add(7);

            List<int> denominators = new List<int>();
            denominators.Add(9);
            denominators.Add(20);
            denominators.Add(27);
            denominators.Add(20);

            Console.WriteLine("    Solving:");
            // Print as fraction
            foreach (int n in numerators)
            {
                Console.Write(String.Format("{0,13}", n));
            }
            Console.Write(Environment.NewLine + String.Format("{0,12}", " "));
            for (int i = 0; i < numerators.Count - 1; i++)
            {
                Console.Write(String.Format("{0}", "-     /      "));
            }
            Console.WriteLine(String.Format("{0,1}", "-"));
            foreach (int d in denominators)
            {
                Console.Write(String.Format("{0,13}", d));
            }
            Console.WriteLine();

            // use the DivideFraction class
            DivideFraction div_fract = new DivideFraction(numerators, denominators);
            int[] solution = div_fract.doDivide();

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(String.Format("{0,25}", solution[0]));
            Console.WriteLine(String.Format("{0,25}", "Answer   =   -"));
            Console.WriteLine(String.Format("{0,25}", solution[1]));

        }
    }
}
