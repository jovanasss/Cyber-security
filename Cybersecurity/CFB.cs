using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity
{
   
    class CFB
    {
        private static Random random = new Random();
        public string Encode(string tekst,int N,string initV)
        {
            string result = "";
            List<string> blocks = dividestring(tekst, N, 'w');
            //string initV = RandomString(N);
            A51 a = new A51();
            a.setKey("0101001000011010110001110001100100101001000000110111111010110111");
            byte[] initE = a.encrypt(Encoding.ASCII.GetBytes(initV));
            string rez;
            for(int i=0;i<blocks.Count;i++)
            {
                rez= XORStrings(blocks[i], System.Text.Encoding.Default.GetString(initE));
                result += rez;
                initE = a.encrypt(Encoding.ASCII.GetBytes(rez));
            }
            return result;
        }

        public string Decode(string tekst, int N, string initV)
        {
            string result = "";
            List<string> blocks = dividestring(tekst, N, 'w');
            //string initV = RandomString(N);
            A51 a = new A51();
            a.setKey("0101001000011010110001110001100100101001000000110111111010110111");
            byte[] initE = a.encrypt(Encoding.ASCII.GetBytes(initV));
            string rez;
            for (int i = 0; i < blocks.Count; i++)
            {
                rez = XORStrings(blocks[i], System.Text.Encoding.Default.GetString(initE));
                result += rez;
                initE = a.encrypt(Encoding.ASCII.GetBytes(rez));
            }
            return result;
        }

        public static string XORStrings(string data, string key)
        {
            int dataLen = data.Length;
            int keyLen = key.Length;
            char[] output = new char[dataLen];

            for (int i = 0; i < dataLen; ++i)
            {
                output[i] = (char)(data[i] ^ key[i % keyLen]);
            }

            return new string(output);
        }

        //stavi onamo gde pozivas cfb
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklemopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static List<string> dividestring(string str, int K,
                                  char ch)
        {
            int N = str.Length;
            int j = 0;
            List<string> result = new List<string>();
            string res = "";
            while (j < N)
            {
                res += str[j];
                if (res.Length == K)
                {
                    result.Add(res);
                    res = "";
                }
                j++;
            }

            if (res != "")
            {
                while (res.Length < K)
                {
                    res += ch;
                }
                result.Add(res);
            }
            return result;
        }
    }
}
