using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity
{
    public enum crypto_algorithm
    {
        PLAYFAIR,
        RSA,
        A51
    }
    class CryptoManager
    {
        public static string Encrypt(string text,crypto_algorithm algoritam,bool shaOn,string[] keys,bool cfb1)
        {
            string result = "";
            if (shaOn)
            {
                SHA2 sha2 = new SHA2();
                result += sha2.DigestString(text);
                result += '\n';
            }
           
            switch(algoritam)
            {
                case crypto_algorithm.RSA:
                    BigInteger E = BigInteger.Parse(keys[0]);
                    BigInteger N = BigInteger.Parse(keys[1]);
                    RSA rsa = new RSA();
                   
                        result += rsa.EncryptText(text, E, N);
                   
                    break;
                case crypto_algorithm.PLAYFAIR:
                    string key = "monarchy";
                    Playfair pf = new Playfair();
                    pf.GetMatrix(key);
                  
                      result += pf.Encode(text.ToCharArray());
                   
                    break;
                case crypto_algorithm.A51:
                    A51 a = new A51();
                    byte[] pom;
                    a.setKey("0101001000011010110001110001100100101001000000110111111010110111");
                    if(!cfb1)
                         pom=a.encrypt(Encoding.ASCII.GetBytes(text));
                    else
                    {
                        CFB cfb = new CFB();
                        pom= Encoding.ASCII.GetBytes(cfb.Encode(text, text.Length, getstr(text.Length)));
                    }
                    string str = "";
                    foreach (byte b in pom)
                        str += b.ToString("000");
                    result += str;
                    break;
            }
            return result;

        }
        static string getstr(int n)
        {
            string str = "";
            for (int i = 0; i < n; i++)
                str += 'a';
            return str;
        }
        public static string Decrypt(string text, crypto_algorithm algoritam, bool shaOn, string[] keys,bool cfb1)
        {
            StringReader sr = new StringReader(text);
            string firstLine = "";
            if (shaOn)
            {
                firstLine = sr.ReadLine();
            }
            string message = sr.ReadToEnd();
            string result = "";
            switch(algoritam)
            {
                case crypto_algorithm.RSA:
                    BigInteger D = BigInteger.Parse(keys[0]);
                    BigInteger N = BigInteger.Parse(keys[1]);
                    RSA rsa = new RSA();
                   
                        result = rsa.DecryptText(message, D, N);
                    
                    break;
                case crypto_algorithm.PLAYFAIR:
                    string key = "monarchy";
                    Playfair pf = new Playfair();
                    pf.GetMatrix(key);
                    
                        result += pf.Decode(message);
                   
                       
                    
                    break;
                case crypto_algorithm.A51:
                    A51 a = new A51();
                    a.setKey("0101001000011010110001110001100100101001000000110111111010110111");
                    byte[] bytes = new byte[message.Length / 3];
                    int j = 0;
                    for (int i = 0; i < message.Length; i += 3)
                    { var str=message.Substring(i, 3);
                        bytes[j++] = byte.Parse(str);
                    }
                    if (!cfb1)
                    {
                        var pom = a.decrypt(bytes);
                        result += System.Text.Encoding.Default.GetString(pom);
                    }
                    else
                    {
                        CFB cfb = new CFB();
                        result += cfb.Decode(System.Text.Encoding.Default.GetString(bytes), message.Length/3,getstr(message.Length / 3));
                    }
                    break;
            }
            if(shaOn)
            {
                SHA2 sha2 = new SHA2();
                if(algoritam!=crypto_algorithm.PLAYFAIR)
                if (firstLine != sha2.DigestString(result))
                    return "";
            }
            return result;
        }

        public static string[] GenerateKeys(crypto_algorithm algoritam,bool pcbc)
        {
            switch(algoritam)
            {
                case crypto_algorithm.RSA:
                    RSA rsa = new RSA();
                    rsa.GenerateKeys();
                    if(!pcbc)
                    return new string[] { rsa.E.ToString(), rsa.N.ToString(), rsa.D.ToString() };
                    else
                    {
                        Random rnd1 = new Random();
                        char initVector = (char)( rnd1.Next(0, 78)+48);
                        return new string[] { rsa.E.ToString(), rsa.N.ToString(), rsa.D.ToString(),initVector.ToString() };
                    }
                default:
                    break;

            }
            return new string[] { };
        }

    }
}
