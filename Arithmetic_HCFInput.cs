using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            // Collect input
            string collect_input; // For collecting user input

            List<int> set = new List<int>();

            Console.WriteLine("Welcome to our Find H.C.F. program.");
            Console.WriteLine("Enter your series of number for H.C.F.");
            Console.WriteLine("Type 'done' when you are through with entering your numbers.\n");

            string collect_input_text = "Enter First Number:  ";
            try
            {
                do
                {
                    // Get keyboard input
                Console.Write(collect_input_text);
                    collect_input = Console.ReadLine();
                    if (Regex.IsMatch(collect_input, @"[0-9]+"))
                    {
                        if (int.Parse(collect_input) != 0)
                        {
                            set.Add(int.Parse(collect_input));
                            collect_input_text = "Enter Next Number:  ";
                        }
                        else
                        {
                            Console.WriteLine("You cannot enter zero. Repeat that!Type 'done' when you're finished.");
                        }
                    }
                    else if (!"DONE".Equals(collect_input.ToUpper()))
                    {
                        Console.WriteLine("Wrong Input. Repeat that!\r\n Type 'done' when you're finished.");
                    }
                } while (!"DONE".Equals(collect_input.ToUpper()));
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            FastHCF h_c_f = new FastHCF(set);
            Console.WriteLine("The H.C.F. of " + String.Join(", ", set) + " is " + h_c_f.getHCF());

        }
    }
}
