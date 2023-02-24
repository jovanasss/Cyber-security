using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity
{
    class Parallelisation
    {
        public void A51ParallelEncryption(int n,string filename,string destination)
        {
            A51 a = new A51();
            a.setKey("0101001000011010110001110001100100101001000000110111111010110111");
            foreach (var line in File.ReadLines(filename).AsParallel().WithDegreeOfParallelism(n))
            {
                var result= a.encrypt(Encoding.ASCII.GetBytes(line));
                string encrypted=System.Text.Encoding.Default.GetString(result);
                FileStream fs = null;
                try
                {
                    fs = new FileStream(destination+"\\paralelizacijaa51.txt", FileMode.Append);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(encrypted);
                    }

                }
                finally
                {
                    if (fs != null)
                        fs.Dispose();

                }

            }
        }
    }
}
