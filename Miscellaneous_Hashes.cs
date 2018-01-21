using System;
using System.Numerics;
using System.Collections.Generic;

namespace Miscellaneous_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] message = "merry xmas".ToCharArray();

            Hashes one_way = new Hashes();
            String hashed = one_way.hashWord(message);

            Console.WriteLine("Message is '" + String.Join("", message) +
                "';\nMessage hash is " + hashed);
        }
    }
}
