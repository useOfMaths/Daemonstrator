using System;
using System.Collections.Generic;

namespace Miscellaneous_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> goods;
            goods = new List<String>() { "Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda" };
            Permutation perm = new Permutation();
            List<String[]> result = perm.possibleWordPermutations(goods, 5);
            // print choices and operation
            Console.Write("[ ");
            foreach (string choice in perm.words)
            {
                Console.Write(choice + "; ");
            }
            Console.WriteLine("] permutation " + perm.r + ":" + Environment.NewLine);
            // print out permutations nicely
            foreach (String[] set in result)
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
