using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CyberSecurity
{
    class RSA
    {
        public BigInteger N { get; set; }
        public BigInteger E { get; set; }
        public BigInteger D { get; set; }



        public void GenerateKeys()
        {
            BigInteger p = LargeNumberGenerator.GenerateLargePrime();
            BigInteger q = LargeNumberGenerator.GenerateLargePrime();
            N = BigInteger.Multiply(p, q);
            BigInteger eulerN = BigInteger.Multiply(p - 1, q - 1);

            do
            {
                E = LargeNumberGenerator.GenerateRandomBigInteger(1, eulerN);
            }
            while (BigInteger.GreatestCommonDivisor(eulerN, E) != 1);
            D = modInverse(E, eulerN);



        }


        public BigInteger Encrypt(BigInteger number,BigInteger E,BigInteger N)
        {

            return BigInteger.ModPow(number, E, N);
        }

        public BigInteger Decrypt(BigInteger number,BigInteger D,BigInteger N)
        {
            return BigInteger.ModPow(number, D, N);
        }

        private string PrependLeadingZeroes(string str, int numOfZeroes)
        {
            string zeroes = "";
            for (int i = 0; i < numOfZeroes; i++)
                zeroes = zeroes + "0";
            return zeroes + str;
        }

        public string EncryptText(string tekst,BigInteger E,BigInteger N)
        {
            char[] characters = tekst.ToCharArray();
            string output = "";

            for (int i = 0; i < characters.Length; i++)
            {
                string encryptedChar = this.Encrypt(characters[i],E,N).ToString();
                encryptedChar = encryptedChar.Length % N.ToString().Length == 0 ? encryptedChar : this.PrependLeadingZeroes(encryptedChar, N.ToString().Length - encryptedChar.Length % N.ToString().Length);
                output += encryptedChar;
            }

            return output;

        }

        public string EncryptWithPCBC(string tekst,BigInteger E,BigInteger N,char initVector)
        {
            
            char[] characters = tekst.ToCharArray();
            string output = "";

           
            BigInteger xored = initVector ^ characters[0];
           // string xor= Convert.ToString((int)xored);
           // string forEncryption = this.PrependLeadingZeroes(xor, N.ToString().Length - xor.Length % N.ToString().Length);
            for(int i=0;i<characters.Length;i++)
            {
                

                BigInteger encryptedChar = this.Encrypt(xored, E, N);
                 string encryptedChar1 = encryptedChar.ToString().Length % N.ToString().Length == 0 ? encryptedChar.ToString() : this.PrependLeadingZeroes(encryptedChar.ToString(), N.ToString().Length - encryptedChar.ToString().Length % N.ToString().Length);
                output += encryptedChar1;
                if (i < characters.Length - 1)
                {
                    string prevChar= Convert.ToString((int)characters[i]);
                    string nextChar= Convert.ToString((int)characters[i+1]);
                    string prevPlainBlock = this.PrependLeadingZeroes(prevChar, N.ToString().Length - prevChar.Length % N.ToString().Length);
                    string plainBlock = this.PrependLeadingZeroes(nextChar, N.ToString().Length - nextChar.Length % N.ToString().Length);
                    xored = new BigInteger(characters[i]) ^ encryptedChar ^new BigInteger( characters[i+1]);
                }
            }

            return output;

        }

        public string DecryptWithPCBC(string tekst, BigInteger D, BigInteger N,char initVector)
        {
           // string[] characters = tekst.Split(' ');
            int chunkLength = N.ToString().Length;
            string output = "";
            BigInteger prevEncrypted=0;
            BigInteger prevPlainText=0;
            for (int i = 0; i < tekst.Length; i += chunkLength)
            {
                string encrypted = tekst.Substring(i, chunkLength);
                
                BigInteger decoded = this.Decrypt(BigInteger.Parse(encrypted), D, N);
                int plainText;
                if (i == 0)
                    //plainText = this.XORStrings(initVector.ToString(), decoded);
                    plainText = (int)(decoded ^ (BigInteger)initVector);
                else
                    plainText = (int)(prevPlainText ^ prevEncrypted ^ decoded);

                //output += char.ConvertFromUtf32((int)BigInteger.Parse(plainText));
                output +=(char) plainText;
                prevEncrypted = BigInteger.Parse(encrypted);
                prevPlainText = plainText;
            }
            return output;
        }
        private string XORStrings(string s1,string s2)
        {
            char[] rez=new char[s1.Length];
            for(int i=0;i<s1.Length;i++)
            {
                rez[i] = (char)(s1[i] ^ s2[i]);
            }
            return new string(rez);
        }

        public string DecryptText(string tekst,BigInteger D,BigInteger N)
        {
            string[] characters = tekst.Split(' ');
            int chunkLength = N.ToString().Length;
            string output = "";
            for (int i = 0; i < tekst.Length; i += chunkLength)
            {
                string encrypted = tekst.Substring(i, chunkLength);
                int decoded = (int)this.Decrypt(BigInteger.Parse(encrypted),D,N);
                output += Char.ConvertFromUtf32(decoded);
            }
            return output;



        }
        static BigInteger modInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m;
            BigInteger y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                // q is quotient
                BigInteger q = a / m;

                BigInteger t = m;

                // m is remainder now, process
                // same as Euclid's algo
                m = a % m;
                a = t;
                t = y;

                // Update x and y
                y = x - q * y;
                x = t;
            }
            // Make x positive
            if (x < 0)
                x += m0;

            return x;
        }

    }
}
