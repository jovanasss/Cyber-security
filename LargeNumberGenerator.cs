using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;

namespace CyberSecurity
{
    class LargeNumberGenerator
    {
        public static BigInteger GenerateLargePrime()
        {
            BigInteger k;
            do
            {
                k = GenerateRandomBigInteger(10000, BigInteger.Parse("340282366920938463463374607431768211456 "));

            }
            while (!IsPrime(k, 40));
            return k;
        }

        public static BigInteger GenerateRandomBigInteger(BigInteger minValue, BigInteger maxValue)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[maxValue.ToByteArray().LongLength];
            BigInteger a;
            do
            {
                rng.GetBytes(bytes);
                a = new BigInteger(bytes);
            }
            while (a < minValue || a > maxValue);
            return a;
        }


        //Rabin-Milerov test za prost broj
        //n-broj koji ispitujemo, k-broj testova
        private static bool IsPrime(BigInteger n, int k)
        {
            if (n == 2 || n == 3)
                return true;
            if (n < 2 || n % 2 == 0)
                return false;
            BigInteger d = n - 1;
            int s = 0;
            while (d % 2 == 0)
            {
                s++;
                d = d / 2;
            }

            for (int i = 0; i < k; i++)
            {
                BigInteger a = LargeNumberGenerator.GenerateRandomBigInteger(2, n - 2);
                BigInteger x = BigInteger.ModPow(a, d, n);
                if (x == 1 || x == n - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == 1)
                        return false;
                    if (x == n - 1)
                        break;
                }
                if (x != n - 1)
                    return false;

            }
            return true;

        }
    }
}
