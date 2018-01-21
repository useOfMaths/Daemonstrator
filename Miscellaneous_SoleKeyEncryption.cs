using System;

namespace Miscellaneous_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] message = "merry xmas".ToCharArray();
            char[] key = "A5FB17C4D8".ToCharArray(); // you might want to avoid zeroes
            SoleKeyEncryption go_secure = new SoleKeyEncryption();

            string[] encrypted = go_secure.encodeWord(message, key);
            Console.WriteLine("Message is '" + String.Join("", message) +
                "';\nEncrypted version is " + String.Join(", ", encrypted));

            string decrypted = go_secure.decodeWord(encrypted, key);
            Console.WriteLine("\n\nDecrypted version is '" + decrypted + "'.");
        }
    }
}
