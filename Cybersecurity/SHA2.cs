using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity
{
    class SHA2
    {
        private UInt32[] h = new UInt32[8] { 0x6a09e667, 0xbb67ae85, 0x3c6ef372, 0xa54ff53a, 0x510e527f, 0x9b05688c, 0x1f83d9ab, 0x5be0cd19 };
        private UInt32[] k = new UInt32[64] {   0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
   0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
   0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
   0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
   0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
   0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
   0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
   0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
};
        public bool[] ByteToBoolArray(byte b)
        {
            bool[] boolArray = new bool[8];
            for (int i = 0; i < 8; i++)
            {
                boolArray[8 - i - 1] = b % 2 != 0;
                b /= 2;
            }
            return boolArray;
        }

        public byte BoolArrayToByte(bool[] array)
        {
            byte rez = 0;
            byte stepen = 1;
            for (int i = 7; i >= 0; i--)
            {
                if (array[i])
                    rez += stepen;
                stepen *= 2;
            }
            return rez;
        }

        public string DigestString(string message)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(message);
            bool[] bitsArray = new bool[8 * bytes.Length];
            int ind = 0;
            foreach (byte bajt in bytes)
                foreach (bool bit in this.ByteToBoolArray(bajt))
                    bitsArray[ind++] = bit == true;
            bool[] rez = Digest(bitsArray.ToList());
            List<List<bool>> byteChunks = this.SplitIntoChunks(rez.ToList(), 8);
            byte[] rezBytes = new byte[byteChunks.Count];
            int indR = 0;
            foreach (List<bool> byteChunk in byteChunks)
            {
                byte b = this.BoolArrayToByte(byteChunk.ToArray());
                rezBytes[indR++] = (byte)(b % 78 + 48);
            }

            return System.Text.Encoding.UTF8.GetString(rezBytes);


        }
        public bool[] Digest(List<bool> message)
        {
            this.Intialize();
            List<bool> preprocessedMess = this.Preprocessing(message);
            List<List<bool>> blocks = this.SplitIntoChunks(preprocessedMess, 512);
            for (int i = 0; i < blocks.Count; i++)
            {
                this.ProcessBlock(blocks[i]);
            }
            bool[] hash = new bool[256];
            for (int i = 0; i < 8; i++)
            {
                bool[] arr = this.UInt32ToBoolArray(h[i]);
                for (int j = 0; j < 32; j++)
                    hash[i * 32 + j] = arr[j];
            }
            return hash;
        }
        public List<bool> Preprocessing(List<bool> message)
        {

            message.Add(true);
            int k = (448 - message.Count % 512) % 512;
            if (k < 0)
                k += 512;
            bool[] zerosArray = new bool[k];

            for (int i = 0; i < zerosArray.Length; i++)
                zerosArray[i] = false;
            message.AddRange(zerosArray);
            bool[] lenArray = new bool[64];
            int len = message.Count;
            int indeks = 63;
            while (len > 0)
            {
                lenArray[indeks--] = len % 2 == 0 ? false : true;
                len = len / 2;
            }
            for (int i = 0; i < 64; i++)
                lenArray[i] = false;
            message.AddRange(lenArray);
            return message;

        }

        public List<List<bool>> SplitIntoChunks(List<bool> message, int chunkSize)
        {
            List<List<bool>> blokovi = new List<List<bool>>(message.Count / chunkSize);
            for (int i = 0; i < message.Count / chunkSize; i++)
            {
                blokovi.Add(new List<bool>(chunkSize));
                for (int j = 0; j < chunkSize; j++)
                {

                    blokovi[i].Add(message[i * chunkSize + j]);
                }
            }
            return blokovi;
        }

        public List<UInt32> SplitBlockIntoUInt32(List<bool> block)
        {
            List<List<bool>> words = this.SplitIntoChunks(block, 32);
            List<UInt32> rez = new List<UInt32>();
            for (int i = 0; i < words.Count; i++)
                rez.Add(this.BoolArrayToUInt32(words[i].ToArray()));
            return rez;
        }

        public void Intialize()
        {
            this.h = new UInt32[8] { 0x6a09e667, 0xbb67ae85, 0x3c6ef372, 0xa54ff53a, 0x510e527f, 0x9b05688c, 0x1f83d9ab, 0x5be0cd19 };
            this.k = new UInt32[64] {   0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
   0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
   0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
   0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
   0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
   0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
   0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
   0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
};
        }

        public void ProcessBlock(List<bool> block)
        {
            List<UInt32> words = GenerateWArrayForBlock(block);
            //inicijalizacija promenljivih
            UInt32 a = this.h[0];
            UInt32 b = this.h[1];
            UInt32 c = this.h[2];
            UInt32 d = this.h[3];
            UInt32 e = this.h[4];
            UInt32 f = this.h[5];
            UInt32 g = this.h[6];
            UInt32 h = this.h[7];
            //runde
            for (int i = 0; i < 63; i++)
            {
                UInt32 s0 = this.RightRotateKTimes(a, 2) ^ this.RightRotateKTimes(a, 13) ^ this.RightRotateKTimes(a, 22);
                UInt32 ma = (a & b) ^ (a & c) ^ (b & c);
                UInt32 t2 = s0 + ma;
                UInt32 s1 = this.RightRotateKTimes(e, 6) ^ this.RightRotateKTimes(e, 11) ^ this.RightRotateKTimes(e, 25);
                UInt32 ch = (e & f) ^ (~e & g);
                UInt32 t1 = h + s1 + ch + k[i] + words[i];

                h = g;
                g = f;
                f = e;
                e = d + t1;
                d = c;
                c = b;
                b = a;
                a = t1 + t2;

            }
            this.h[0] = this.h[0] + a;
            this.h[1] = this.h[1] + b;
            this.h[2] = this.h[2] + c;
            this.h[3] = this.h[3] + d;
            this.h[4] = this.h[4] + e;
            this.h[5] = this.h[5] + f;
            this.h[6] = this.h[6] + g;
            this.h[7] = this.h[7] + h;


        }

        public List<UInt32> GenerateWArrayForBlock(List<bool> blok)
        {
            //List<List<bool>> words=new List<List<bool>>(64)
            List<UInt32> words = this.SplitBlockIntoUInt32(blok);
            for (int i = 16; i <= 63; i++)
            {
                UInt32 s0 = this.RightRotateKTimes(words[i - 15], 7) ^ this.RightRotateKTimes(words[i - 15], 18) ^ words[i - 15] >> 3;
                UInt32 s1 = this.RightRotateKTimes(words[i - 2], 17) ^ this.RightRotateKTimes(words[i - 2], 19) ^ words[i - 2] >> 10;
                words.Add(words[i - 16] + s0 + words[i - 7] + s1);


            }
            return words;
        }

        public UInt32 RightRotateKTimes(UInt32 message, int k)
        {
            return message >> k | message << (32 - k);
        }




        public UInt32 BoolArrayToUInt32(bool[] arr)
        {
            UInt32 rez = 0;
            UInt32 factor = 1;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                rez += arr[i] == true ? factor : 0;
                factor *= 2;

            }
            return rez;
        }
        public bool[] UInt32ToBoolArray(UInt32 num)
        {
            bool[] message = new bool[32];
            UInt32 k = num;
            int indeks = 31;
            for (int i = 0; i < 32; i++)
                message[i] = false;
            while (k > 0)
            {
                message[indeks--] = k % 2 == 0 ? false : true;
                k /= 2;
            }
            return message;
        }



    }
}
