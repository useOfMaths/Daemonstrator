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
            * List Prime Numbers.
             */
            int candidate = 48;
            List<int> answer;

            ListFactors factors = new ListFactors(candidate);
            answer = factors.doBusiness();

            Console.WriteLine("Factors of " + candidate + " are:");
            Console.WriteLine(String.Join(", ", answer));

        }
    }
}
