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
            * Adding fractions
             */
            List<int> numerators = new List<int>();
            numerators.Add(1);
            numerators.Add(1);
            numerators.Add(1);
            numerators.Add(1);

            List<int> denominators = new List<int>();
            denominators.Add(4);
            denominators.Add(4);
            denominators.Add(4);
            denominators.Add(4);

            Console.WriteLine("    Solving:");
            // Print as fraction
            foreach (int n in numerators)
            {
                Console.Write(String.Format("{0,13}", n));
            }
            Console.Write(Environment.NewLine + String.Format("{0,12}", " "));
            for (int i = 0; i < numerators.Count - 1; i++)
            {
                Console.Write(String.Format("{0}", "-     +      "));
            }
            Console.WriteLine(String.Format("{0,1}", "-"));
            foreach (int d in denominators)
            {
                Console.Write(String.Format("{0,13}", d));
            }
            Console.WriteLine();

            // use the AddFraction class
            AddFraction add_fract = new AddFraction(numerators, denominators);
            int[] solution = add_fract.doAdd();

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(String.Format("{0,25}", solution[0]));
            Console.WriteLine(String.Format("{0,25}", "Answer   =   -"));
            Console.WriteLine(String.Format("{0,25}", solution[1]));

        }
    }
}
