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
            * Find LCM.
             */
            List<int> set = new List<int>();
            set.Add(12);
            set.Add(18);
            set.Add(24);

            LCM LCM = new LCM(set);

            Console.WriteLine("The L.C.M. of " + String.Join(", ", set) + " is " + LCM.getLCM());

        }
    }
}
