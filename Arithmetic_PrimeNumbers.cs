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
            int start = 1;
            int end = 100;
            List<int> answer;

            PrimeNumbers my_list = new PrimeNumbers(5, 500);
            answer = my_list.getPrimes();

            Console.WriteLine("Prime numbers between " + start + " and " + end + " are:");
            Console.WriteLine(String.Join(", ", answer));

        }
    }
}
