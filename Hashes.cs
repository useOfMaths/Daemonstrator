using System;
using System.Numerics;
using System.Globalization;

namespace Miscellaneous_CS
{
    class Hashes
    {

        public Hashes()
        {
        }

        public String hashWord(char[] msg)
        {
            // encoding eqn { Tn = (n-2)t1 + 2^n } - please use your own eqn
            String hash = "";
            BigInteger big_hash = 0;
            int n;
            int t1;
            BigInteger x;
            for (int i = 0; i < msg.Length; i++)
            {
                // get unicode of this character as n
                n = (int)msg[i];
                t1 = i + 1;
                // use recurrence series equation to hash
                x = BigInteger.Add(BigInteger.Multiply(n-2, t1), BigInteger.Pow(2, n));
                if (i == 0)
                {
                    hash = x.ToString();
                    big_hash = x;
                    continue;
                }

                // convert number from base 10 to base 2
                string binary = "";
                BigInteger remainder = 0;
                do
                {
                    big_hash = BigInteger.DivRem(big_hash, 2, out remainder);
                    binary = remainder.ToString() + binary;
                } while (!big_hash.Equals(BigInteger.Zero));

                // bitwise rotate left with the modulo of x
                x = BigInteger.Remainder(x, binary.Length);

                char[] slice_1 = binary.Substring((int)x).ToCharArray();
                // keep as '1' to preserve hash size
                slice_1[0] = '1';

                string slice_2 = binary.Substring(0, (int)x);

                hash = String.Join("", slice_1) + slice_2;

                // convert number from base 2 to base 10
                big_hash = 0; // not necessary; just stating the obvious
                int j = 0;
                while (j < hash.Length)
                {
                    big_hash = BigInteger.Add(BigInteger.Multiply(int.Parse(hash[j].ToString()), BigInteger.Pow(2, hash.Length - 1 - j)), big_hash);
                    j++;
                }
            }
            hash = big_hash.ToString("X");
            hash = hash.ToUpper();

            return hash;
        }
    }
}
