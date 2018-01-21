using System;
using System.Collections.Generic;
using System.Linq;

namespace Miscellaneous_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] goods = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Selection pick = new Selection();
            List<string[]> result = pick.groupSelection(goods, 3);
            // print choices and operation
            Console.Write("[ ");
            foreach (string choice in pick.words)
            {
                Console.Write(choice + "; ");
            }
            Console.WriteLine("] selection " + pick.r + ":" + Environment.NewLine);
            // print out selections nicely
            foreach (string[] set in result)
            {
                foreach (string member in set)
                {
                    Console.Write(member + "; ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(Environment.NewLine + "Number of ways is " + result.Count + ".");
        }
    }
}
