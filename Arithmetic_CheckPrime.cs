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
            * Test for the primeness of a number.
            */
            int test_guy = 97;
            CheckPrime prime_check = new CheckPrime(test_guy); // Is 97 is prime number?

            string result = "Prime State:\r\n";
            if (prime_check.verifyPrime())
            {
                result += test_guy + " is a prime number.";
            }
            else
            {
                result += test_guy + " is not a prime number.";
            }

            Console.WriteLine(result);

        }
    }
}
