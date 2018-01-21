using System;
using System.Numerics;
using System.Collections.Generic;

namespace Miscellaneous_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                 * STEP I:
             */
            int p1 = 101; // 1st prime
            int p2 = 401; // 2nd prime
            /*
                * STEP II:
            */
            BigInteger semi_prime = new BigInteger(p1 * p2);

            /*
                 * STEP III:
             */
            LCM l_c_m = new LCM(new List<int>() { p1 - 1, p2 - 1 });
            int lcm = l_c_m.getLCM();

            /*
                 * STEP IV:
             */
            // pick a random prime (public_key) that lies
            // between 1 and LCM but not a factor of LCM
            BigInteger public_key = new BigInteger(313);

            // find 'public_key' complement - private_key - such that
            // (public_key * private_key) % LCM = 1
            //this involves some measure of trial and error
            int i = 1;
            while ((lcm * i + 1) % public_key != 0)
            {
                i++;
            }
            /*
                 * STEP V:
             */
            BigInteger private_key = BigInteger.Divide(i * lcm + 1, public_key);

            char[] message = "merry xmas".ToCharArray();
            DualKeyEncryption go_secure = new DualKeyEncryption(semi_prime);

            string[] encrypted = go_secure.encodeWord(message, public_key);
            Console.WriteLine("Message is '" + String.Join("", message) +
                "';\nEncrypted version is " + String.Join(", ", encrypted));

            string decrypted = go_secure.decodeWord(encrypted, private_key);
            Console.WriteLine("\n\nDecrypted version is '" + decrypted + "'.");
        }
    }
}
