using System;
using System.Numerics;
using System.Globalization;

namespace Miscellaneous_CS
{
    class DualKeyEncryption
    {

        BigInteger semi_prime;

        public DualKeyEncryption(BigInteger semi_prime)
        {
            this.semi_prime = semi_prime;
        }

        /*
         * STEP VI:
         */
        public string[] encodeWord(char[] msg, BigInteger key)
        {
            string[] encryption = new string[msg.Length];
            int x;
            for (int i = 0; i < msg.Length; i++)
            {
                // get unicode of this character as x
                x = (int)msg[i];
                // use RSA to encrypt & save in base 16
                encryption[i] = BigInteger.ModPow(x, key, semi_prime).ToString("X");
            }

            return encryption;
        }

        /*
         * STEP VII:
         */
        public string decodeWord(string[] code, BigInteger key)
        {
            String decryption = "";
            BigInteger c;
            for (int i = 0; i < code.Length; i++)
            {
                // use RSA to decrypt
                c = BigInteger.ModPow(BigInteger.Parse(code[i], NumberStyles.HexNumber), key, semi_prime);
                decryption += (char)c;
            }

            return decryption;
        }
    }
}
