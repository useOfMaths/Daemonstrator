using System;
using System.Collections.Generic;

namespace Miscellaneous_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> goods;
            goods = new List<string>() { "Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda" };
            Combination combo = new Combination();
            List<string[]> result = combo.possibleWordCombinations(goods, 3);
            // print choices and operation
            Console.Write("[ ");
            foreach (string choice in combo.words)
            {
                Console.Write(choice + "; ");
            }
            Console.WriteLine("] combination " + combo.r + ":" + Environment.NewLine);
            // print out combinations nicely
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
