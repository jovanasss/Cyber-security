using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity
{
    class PictureConverter
    {
        Random r = new Random();
        string GenerateKey()
        {
            
            string S = "";
            for(int i=0;i<64;i++)
            {
                int num = r.Next() % 2;
                S += num.ToString();
            }
            return S;

        }
        public Bitmap EncryptPicture(Bitmap source)
        {
            A51 a = new A51();
          





            Bitmap dist = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    Color pixel = source.GetPixel(i, j);
                    byte[] bytes = { pixel.R, pixel.G, pixel.B };
                    a.setKey(GenerateKey());
                    byte[] result = a.encrypt(bytes);
                    dist.SetPixel(i, j, Color.FromArgb(result[0], result[1], result[2]));
                }
            return dist;


        }


    }
}
