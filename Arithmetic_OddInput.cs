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
            * Collect input.
             */
            int first;
            int last;
            List<int> answer;
            string collect_input; // For collecting user input

            Console.Write("Enter your start number:   ");
            collect_input = Console.ReadLine();
            first = int.Parse(collect_input); // Convert it to integer

            Console.Write("Enter your stop number:   ");
            collect_input = Console.ReadLine();
            last = int.Parse(collect_input);

            // Use the Odd Number class.
            OddNumbers odd_input = new OddNumbers(first, last);
            answer = odd_input.prepResult();

            Console.WriteLine("Odd numbers between " + first + " and " + last + " are:");
            Console.WriteLine(String.Join(", ", answer));

        }
    }
}
