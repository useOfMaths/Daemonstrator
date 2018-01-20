using System;
using System.Collections.Generic;

namespace Arithmetic_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our demonstration sequels");
            Console.WriteLine("Hope you enjoy (and follow) the lessons.");
            Console.WriteLine("\r\n");

            /*
            * Find HCF.
             */
            List<int> set = new List<int>();
            set.Add(30);
            set.Add(48);
            set.Add(54);

            FastHCF hcf = new FastHCF(set);

            Console.WriteLine("The H.C.F. of " + String.Join(", ", set) + " is " + hcf.getHCF());

        }
    }
}
