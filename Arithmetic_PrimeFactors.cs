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

            ListPrimeFactors prime_factors = new ListPrimeFactors(candidate);
            answer = prime_factors.getPrimeFactors();

            Console.WriteLine("Prime factorising " + candidate + " gives:");
            Console.WriteLine(String.Join(" X ", answer));

        }
    }
}
