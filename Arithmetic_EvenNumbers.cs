﻿using System;
using System.Collections.Generic;

namespace Arithmetic_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our demonstration sequels");
            Console.WriteLine("Hope you enjoy (and follow) the lessons.");
            Console.WriteLine("");

            /* Use the Even Number class. */
            int first = 1;
            int last = 100;
            List<int> answer;

            EvenNumbers even_data = new EvenNumbers(first, last); // even numbers between 1 and 100
            answer = even_data.prepResult();

            Console.WriteLine("Even numbers between " + first + " and " + last + " are:");
            Console.WriteLine(String.Join(", ", answer));

        }
    }
}