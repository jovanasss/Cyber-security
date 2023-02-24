using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity
{
    class Playfair
    {
        Dictionary<char, string> dict = new Dictionary<char, string>();
        char[,] matrix = new char[5, 5];

        public void GetMatrix(string key)
        {
            
            List<char> alphabet = new List<char>{ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            for (int i = 0; i < key.Length; i++)
            {
                int x = i / 5;
                int y = i % 5;
                dict[key[i]] = x.ToString() + y.ToString();
                matrix[x,y] = key[i];
                if (alphabet.Contains(key[i]))
                    if (key[i] == 'i' || key[i] == 'j')
                    {
                        alphabet.Remove('i');
                       // alphabet.Remove('j');
                    }
                    else
                        alphabet.Remove(key[i]);
                
            }
            for(int i=0;i<alphabet.Count;i++)
            {
                int x = (key.Length + i) / 5;
                int y= (key.Length + i) % 5;
              //  if (alphabet[i] != 'j')
               // {
                    dict[alphabet[i]] = x.ToString() + y.ToString();
                    matrix[x, y] = alphabet[i];
               // }
            }
            

        }
        public string Encode(char[] plaintext)
        {
            string result = "";
            plaintext = new string(plaintext).ToLower().ToCharArray();
            plaintext= plaintext.Where(x => !Char.IsWhiteSpace(x)).ToArray();
            for (int i = 0; i < plaintext.Length; i++)
            {
                
                if (plaintext[i] == 'j') plaintext[i] = 'i';
                if (i+1>=plaintext.Length) 
                    result+=new string(playfairEncode(plaintext[i], 'x'));
                else
                {
                    if (plaintext[i + 1] == 'j') plaintext[i + 1] = 'i';
                    if (plaintext[i] == plaintext[i + 1]) 
                        result+=new string(playfairEncode(plaintext[i], 'x'));
                    else
                    {
                        result+=new string(playfairEncode(plaintext[i], plaintext[i + 1]));
                        i++;
                    }
                }
            }
            return result;
        }
        public string Decode(string encoded)
        {
            string result = "";
            for (int i = 0; i < encoded.Length; i += 2)
                result += new string(playfairDecode(encoded[i], encoded[i + 1]));
            string result1 ="";
            for(int i=0;i<result.Length;i++)
            {
                if (result[i] != 'x')
                    result1 += result[i];
                if (result[i] == 'x' && i != 0 && i != result.Length - 1)
                    if (result[i - 1] != result[i + 1])
                        result1 += result[i];
                        
                
            }    
            return result1;


        }

        private char[] playfairDecode(char ch1, char ch2)
        {
            int w, x, y, z;
            string wx = dict[ch1];
            w = Int16.Parse(wx[0].ToString());
            x = Int16.Parse(wx[1].ToString());
            string yz = dict[ch2];
            y = Int16.Parse(yz[0].ToString());
            z = Int16.Parse(yz[1].ToString());
            char[] result = new char[2];

            if (w == y)
            {
                x =x==0?4: (x - 1) % 5;
                z = z==0?4:(z - 1) % 5;

                result[0] = matrix[w, x];
                result[1] = matrix[y, z];

            }
            else if (x == z)
            {
                w = w == 0 ? 4: (w - 1) % 5;
                y = y==0?4:(y - 1) % 5;
                result[0] = matrix[w, x];
                result[1] = matrix[y, z];

            }
            else
            {
                result[0] = matrix[w, z];
                result[1] = matrix[y, x];

            }
            return result;
        }

        char[] playfairEncode(char ch1,char ch2)
        {
            int w, x, y, z;
            string wx = dict[ch1];
            w =Int16.Parse(wx[0].ToString());
            x = Int16.Parse(wx[1].ToString());
            string yz = dict[ch2];
            y = Int16.Parse(yz[0].ToString());
            z = Int16.Parse(yz[1].ToString());
            char[] result=new char[2];

            if (w == y)
            {
                x = (x + 1) % 5;
                z = (z + 1) % 5;
             
                result[0] = matrix[w,x];
                result[1] = matrix[y, z];
                
            }
            else if (x == z)
            {
                w = (w + 1) % 5;
                y = (y + 1) % 5;
                result[0] = matrix[w, x];
                result[1] = matrix[y, z];
              
            }
            else
            {
                result[0] = matrix[w, z];
                result[1] = matrix[y, x];
               
            }
            return result;
        }
    }
    static class Alphabet
    {
        public static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    }
}
