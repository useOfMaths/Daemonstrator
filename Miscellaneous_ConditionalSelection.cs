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
            ConditionalSelection choose = new ConditionalSelection();
            List<string[]> result = choose.limitedSelection(goods, 4,
             //      minimum number of occurrences           maximum number of occurrences
                new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 1, 0 }, new int[] { 4, 3, 2, 4, 3, 2, 4, 3, 2, 4 });
            // print choices and operation
            Console.Write("[ ");
            foreach (string choice in choose.words)
            {
                Console.Write(choice + "; ");
            }
            Console.WriteLine("] conditioned selection " + choose.r + ":" + Environment.NewLine);
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
