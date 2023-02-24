using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CyberSecurity
{
    class FileSystem
    {
        private FileSystemWatcher watcher;
        private string watchedDirectory;
        private string outputDirectory;
        private bool isWatcherOn;
        private Random rnd;
        private string keyFile = @"./keys.txt";
        private RSA rsa;

        // private Dictionary<string, int> savedKeys;
        // private RailFence rf;

        public crypto_algorithm Algorithm {get;set;}
        public bool ShaOn { get; set; }

        public bool CFBon { get; set; }

        public FileSystem()
        {
            
            watcher = new FileSystemWatcher();
            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = false;
            isWatcherOn = false;
            watchedDirectory = "";
            outputDirectory = "";
            rnd = new Random();
            rsa = new RSA();
            Algorithm = 0;
            ShaOn = true;
            CFBon = true;
           // savedKeys = new Dictionary<string, int>();


        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);

            if (outputDirectory.Length != 0)
                this.EncodeTextFile(e.FullPath, this.outputDirectory);
            else
                Console.WriteLine("Output diretory isn't set!");
        }

        public void SetWatchedDirectory(string directory)
        {
            if (!isWatcherOn)
                if (outputDirectory.Length == 0 || outputDirectory.CompareTo(directory) != 0)
                {
                    this.watchedDirectory = directory;
                    watcher.Path = directory;
                }

        }

      /*  public void SetNewKey(int key)
        {
            rf.SetKey(key);
        }*/
        public void SetOutputDirectory(string dir)
        {
            if (!isWatcherOn)
            {
                if (watchedDirectory.Length == 0 || watchedDirectory.CompareTo(dir) != 0)
                    this.outputDirectory = dir;
            }
        }

        public bool IsWatcherSystemOn()
        {
            return this.isWatcherOn;
        }

        public string GetTargetDirectory()
        {
            return this.watchedDirectory;
        }
        public string GetDestinationDirectory()
        {
            return this.outputDirectory;
        }

        public void TurnOnFileSystemWatcher()
        {
            if (this.watchedDirectory == "" || this.outputDirectory == "")
                throw new Exception("You need to specify target and destination folders before turning on File Watcher System!");
            if (!isWatcherOn)
            {
                isWatcherOn = true;
                watcher.EnableRaisingEvents = true;
            }
        }

        public void TurnOffFileSystemWatcher()
        {
            if (isWatcherOn)
            {
                isWatcherOn = false;
                watcher.EnableRaisingEvents = false;
            }
        }

        public void EncodeAllFilesFromDirectory(string path)
        {
            if (this.outputDirectory.Length == 0)
                throw new Exception("Destination folder not set!");
            foreach (string txtFile in Directory.GetFiles(path, "*.txt"))
                this.EncodeTextFile(txtFile, this.outputDirectory);
        }

        public bool EncodeTextFile(string fullFileName, string outputDirectory)
        {
            string outputFileName = outputDirectory + @"\" + Path.GetFileName(fullFileName);
            string textForCoding = this.ReadTextFile(fullFileName);
            string encodedText;
            string[] keys = CryptoManager.GenerateKeys(this.Algorithm,CFBon);
            if (this.Algorithm == crypto_algorithm.RSA)
            {
                encodedText = CryptoManager.Encrypt(textForCoding, this.Algorithm, this.ShaOn, new string[] { keys[0], keys[1] }, CFBon);
                this.WriteKeyToKeyFile(outputFileName, this.Algorithm == crypto_algorithm.RSA ? keys[2] : keys[0], keys[1], this.Algorithm == crypto_algorithm.RSA && CFBon ? keys[3] : "", this.ShaOn, this.Algorithm, this.CFBon);
            }
            else
                encodedText = CryptoManager.Encrypt(textForCoding, this.Algorithm, this.ShaOn, new string[] { }, CFBon);
           
           
            this.WriteToTextFile(outputFileName, encodedText);
               
            return true;
            
            

         }
        private void WriteKeyToKeyFile(string fileName,string numOfRowsKey,string offsetKey,string initVector,bool shaOn,crypto_algorithm alg,bool pcbcOn)
        {
            string sha = shaOn ? "1" : "0";
            string pcbc = pcbcOn ? "1" : "0";
            int algoritam = (int)alg;
            string entry = "";
            if((alg==crypto_algorithm.RSA && pcbcOn==false) )
                 entry = fileName + " " + numOfRowsKey+" "+offsetKey+" "+sha+" "+pcbc+" "+algoritam.ToString();
            else if(alg==crypto_algorithm.RSA)
                entry = fileName + " " + numOfRowsKey + " " + offsetKey + " " + sha + " " + pcbc + " " + algoritam.ToString() + " " + initVector;
            using (StreamWriter sw = File.AppendText(this.keyFile))
            {
                sw.WriteLine(entry);
            }
        }

        public bool DecodeTextFile(string fullFileName, string targetFolder)
        {
            if (this.isWatcherOn) return false;
            string outputFileName = targetFolder + @"\" + Path.GetFileName(fullFileName);
           
            string codedText = this.ReadTextFile(fullFileName);
            string decodedText = "";
            if (this.Algorithm == crypto_algorithm.RSA)
            {
                string keyString = this.GetKey(fullFileName);
                if (keyString == "") return false;
                //string firstKey = keyString.Substring(0, keyString.IndexOf(" "));
                //string secondKey = keyString.Substring(keyString.IndexOf(" ") + 1);
                string[] keys = keyString.Split(' ');
                bool shaOn = keys[2] == "1" ? true : false;
                bool pcbcOn = keys[3] == "1" ? true : false;
                crypto_algorithm algoritam = (crypto_algorithm)int.Parse(keys[4]);
                decodedText = CryptoManager.Decrypt(codedText, algoritam, shaOn, keys, pcbcOn);
            }
            else
                decodedText = CryptoManager.Decrypt(codedText,this.Algorithm, this.ShaOn, new string[] { },this.CFBon);
            

            this.WriteToTextFile(outputFileName, decodedText);
            if (decodedText == "")
                return false;
            return true;
           
        }

        public string GetKey(string fileName)
        {
            string key="";
            using (StreamReader sr = File.OpenText(this.keyFile))
            {
                string s = "";
               
                while ((s = sr.ReadLine()) != null)
                {
                    if(s.StartsWith(fileName))
                    {
                        int index = fileName.Length + 1;
                        key =s.Substring(index);
                        return key;
                    }
                }
            }
            return key;
        }

        private int GenerateKey()
        {
            return rnd.Next(3, 100);
        }

       /* public int GetKey(string path)
        {
            if (savedKeys.ContainsKey(path))
                return savedKeys[path];
            return 0;
        }*/

        private string ReadTextFile(string path)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }


        }

        private void WriteToTextFile(string path, string content)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Create);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(content);
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
