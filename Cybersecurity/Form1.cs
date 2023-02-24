using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CyberSecurity
{
    public enum Alogrithm
    {
        Playfair,
        RSA,
        A51
    }
    public partial class Form1 : Form
    {
        private FileSystem fs;
        public Form1()
        {
            InitializeComponent();
            fs = new FileSystem();
            this.imageDialog.Enabled = false;
            this.groupBox5.Enabled = false;
        }

        private void TurnOnOrOffButtons(bool value)
        {
            this.btnDecodeFile.Enabled = value;
           
            //this.btnChangeTargetFolder.Enabled = value;
            this.btnCodeFilesFromDirectory.Enabled = value;
            this.imageDialog.Enabled = false;
        }

        private void ChooseFolder(TextBox tbResult)
        {
            DialogResult result = this.fbdChooseFolder.ShowDialog();
            if (result == DialogResult.OK)
               
                tbResult.Text = fbdChooseFolder.SelectedPath;
        }

       
       

        private void btnBrowseTargetFolder_Click(object sender, EventArgs e)
        {
           // this.ChooseFolder(this.tbTargetPath);
           
        }

        private void btnChangeTargetFolder_Click(object sender, EventArgs e)
        {
           /* if (Directory.Exists(tbTargetPath.Text))
            {
                fs.SetWatchedDirectory(this.tbTargetPath.Text);
                this.lblTargetFolderName.Text = fs.GetTargetDirectory();
                this.tbTargetPath.Text = "";
            }
            else MessageBox.Show("Invalid directory name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
        }

       
        private void btnBrowseFileToDecode_Click(object sender, EventArgs e)
        {
            this.ofdChooseFile.Filter = "Text|*.txt";
            DialogResult result = this.ofdChooseFile.ShowDialog();
            if (result == DialogResult.OK)
                this.tbDecodeFile.Text = ofdChooseFile.FileName;
        }

        private void btnBrowseDecodeDestFolder_Click(object sender, EventArgs e)
        {
            this.ChooseFolder(this.tbDestDecodeFolder);
        }

        private void btnDecodeFile_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbDestDecodeFolder.Text) && File.Exists(tbDecodeFile.Text))
                try {
                    bool rez=fs.DecodeTextFile(tbDecodeFile.Text, tbDestDecodeFolder.Text);
                    if(rez)
                    MessageBox.Show("Successful decoding!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Hashes don't match!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                MessageBox.Show("Invalid file or directory name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnbrowseEncodePath_Click(object sender, EventArgs e)
        {
            this.ofdChooseFile.Filter = "Text|*.txt";
            DialogResult result = this.ofdChooseFile.ShowDialog();
            if (result == DialogResult.OK)
                this.tbEncodePath.Text = ofdChooseFile.FileName;
        }

        private void btnCodeFilesFromDirectory_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(this.textBox1.Text) && File.Exists(tbEncodePath.Text))
                try
                {
                    bool rez = fs.EncodeTextFile(tbEncodePath.Text, this.textBox1.Text);
                    if (rez)
                        MessageBox.Show("Successful encoding!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                MessageBox.Show("Invalid file or directory name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void rbRSA_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbRSA.Checked)
            {
                this.fs.Algorithm = crypto_algorithm.RSA;
                this.imageDialog.Enabled = false;
                this.groupBox5.Enabled = true;
            }
          
        }

        private void rbRailFence_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbRailFence.Checked)
            {
                this.fs.Algorithm = crypto_algorithm.PLAYFAIR;
                this.imageDialog.Enabled = false;
                this.groupBox5.Enabled = false;
            }
            
           
        }

        private void rbShaOn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbShaOn.Checked)
                this.fs.ShaOn = true;
            else
                this.fs.ShaOn = false;
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void rbCFBOn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cfbOn.Checked)
                this.fs.CFBon = true;
            else
                this.fs.CFBon = false;
        }

      

        private void imageDialog_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Image Files(*.jpg;*.gif;*.bmp;*.png) | *.bmp; *.jpg; *.gif;*.png";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                Bitmap bm = new Bitmap(filePath);
                PictureConverter pc = new PictureConverter();
                
                Bitmap nova = pc.EncryptPicture(bm);
              
                pictureBox1.Image = nova;
                string name = Path.GetDirectoryName(filePath) + "\\novaSlika.png";
                nova.Save(name);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.fs.Algorithm = crypto_algorithm.A51;
                this.imageDialog.Enabled = true;
                this.groupBox5.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ChooseFolder(this.textBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Parallelisation p = new Parallelisation();
            p.A51ParallelEncryption(3, this.tbEncodePath.Text, this.textBox1.Text);
            MessageBox.Show("Successful encoding!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
