using System;
using System.Numerics;
using System.Globalization;

namespace Miscellaneous_CS
{
    class SoleKeyEncryption
    {

        public SoleKeyEncryption()
        {
        }

        public string[] encodeWord(char[] msg, char[] key)
        {
            // encoding eqn { Tn = 3^n-1(2t1 + 1) - 1 } - please use your own eqn
            //                        2
            string[] encryption = new string[msg.Length];
            int n;
            int t1;
            BigInteger Tn;
            for (int i = 0; i < msg.Length; i++)
            {
                // get unicode of this character as t1
                t1 = (int)msg[i];
                // get next key digit as n
                n =  Convert.ToInt32(key[i % (key.Length - 1)].ToString(), 16);
                // use recurrence series equation to encrypt & save in base 16
                Tn = BigInteger.Divide(BigInteger.Subtract(BigInteger.Multiply(BigInteger.Pow(3, n - 1), 2 * t1 + 1), 1), 2);
                encryption[i] = Tn.ToString("X");
            }

            return encryption;
        }

        public string decodeWord(string[] code, char[] key)
        {
            // decoding eqn { t1 = 3^1-n(2Tn + 1) - 1 }
            //                        2
            string decryption = "";
            int n;
            BigInteger t1;
            BigInteger Tn;
            for (int i = 0; i < code.Length; i++)
            {
                Tn = BigInteger.Parse(code[i], NumberStyles.HexNumber);
                // get next key digit as n
                n = Convert.ToInt32(key[i % (key.Length - 1)].ToString(), 16);
                // use recurrence series equation to decrypt
                t1 = BigInteger.Divide(BigInteger.Subtract(BigInteger.Divide(2 * Tn + 1, BigInteger.Pow(3, n - 1)), 1), 2);
                decryption += (char)t1;
            }

            return decryption;
        }
    }
}
