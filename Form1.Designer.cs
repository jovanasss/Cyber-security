
namespace CyberSecurity
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCodeFilesFromDirectory = new System.Windows.Forms.Button();
            this.btnDecodeFile = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnbrowseEncodePath = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbEncodePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBrowseDecodeDestFolder = new System.Windows.Forms.Button();
            this.tbDestDecodeFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseFileToDecode = new System.Windows.Forms.Button();
            this.tbDecodeFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fbdChooseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdChooseFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbRSA = new System.Windows.Forms.RadioButton();
            this.imageDialog = new System.Windows.Forms.Button();
            this.rbRailFence = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbShaOff = new System.Windows.Forms.RadioButton();
            this.rbShaOn = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cfbOff = new System.Windows.Forms.RadioButton();
            this.cfbOn = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCodeFilesFromDirectory
            // 
            this.btnCodeFilesFromDirectory.Location = new System.Drawing.Point(22, 194);
            this.btnCodeFilesFromDirectory.Name = "btnCodeFilesFromDirectory";
            this.btnCodeFilesFromDirectory.Size = new System.Drawing.Size(118, 28);
            this.btnCodeFilesFromDirectory.TabIndex = 3;
            this.btnCodeFilesFromDirectory.Text = "Encrypt File";
            this.btnCodeFilesFromDirectory.UseVisualStyleBackColor = true;
            this.btnCodeFilesFromDirectory.Click += new System.EventHandler(this.btnCodeFilesFromDirectory_Click);
            // 
            // btnDecodeFile
            // 
            this.btnDecodeFile.Location = new System.Drawing.Point(20, 195);
            this.btnDecodeFile.Name = "btnDecodeFile";
            this.btnDecodeFile.Size = new System.Drawing.Size(237, 27);
            this.btnDecodeFile.TabIndex = 4;
            this.btnDecodeFile.Text = "Decode File";
            this.btnDecodeFile.UseVisualStyleBackColor = true;
            this.btnDecodeFile.Click += new System.EventHandler(this.btnDecodeFile_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.btnbrowseEncodePath);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.tbEncodePath);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnCodeFilesFromDirectory);
            this.groupBox3.Location = new System.Drawing.Point(31, 307);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 241);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encrypt Files";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(168, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 28);
            this.button3.TabIndex = 20;
            this.button3.Text = "Parallel A51";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "File to Encode:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(198, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 49);
            this.button2.TabIndex = 13;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnbrowseEncodePath
            // 
            this.btnbrowseEncodePath.Location = new System.Drawing.Point(198, 46);
            this.btnbrowseEncodePath.Name = "btnbrowseEncodePath";
            this.btnbrowseEncodePath.Size = new System.Drawing.Size(70, 55);
            this.btnbrowseEncodePath.TabIndex = 6;
            this.btnbrowseEncodePath.Text = "Browse";
            this.btnbrowseEncodePath.UseVisualStyleBackColor = true;
            this.btnbrowseEncodePath.Click += new System.EventHandler(this.btnbrowseEncodePath_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 124);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 49);
            this.textBox1.TabIndex = 12;
            // 
            // tbEncodePath
            // 
            this.tbEncodePath.Location = new System.Drawing.Point(22, 46);
            this.tbEncodePath.Multiline = true;
            this.tbEncodePath.Name = "tbEncodePath";
            this.tbEncodePath.Size = new System.Drawing.Size(161, 55);
            this.tbEncodePath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Destination Folder:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBrowseDecodeDestFolder);
            this.groupBox4.Controls.Add(this.tbDestDecodeFolder);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btnBrowseFileToDecode);
            this.groupBox4.Controls.Add(this.tbDecodeFile);
            this.groupBox4.Controls.Add(this.btnDecodeFile);
            this.groupBox4.Location = new System.Drawing.Point(427, 307);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(320, 241);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Decode File";
            // 
            // btnBrowseDecodeDestFolder
            // 
            this.btnBrowseDecodeDestFolder.Location = new System.Drawing.Point(198, 124);
            this.btnBrowseDecodeDestFolder.Name = "btnBrowseDecodeDestFolder";
            this.btnBrowseDecodeDestFolder.Size = new System.Drawing.Size(70, 49);
            this.btnBrowseDecodeDestFolder.TabIndex = 10;
            this.btnBrowseDecodeDestFolder.Text = "Browse";
            this.btnBrowseDecodeDestFolder.UseVisualStyleBackColor = true;
            this.btnBrowseDecodeDestFolder.Click += new System.EventHandler(this.btnBrowseDecodeDestFolder_Click);
            // 
            // tbDestDecodeFolder
            // 
            this.tbDestDecodeFolder.Location = new System.Drawing.Point(20, 124);
            this.tbDestDecodeFolder.Multiline = true;
            this.tbDestDecodeFolder.Name = "tbDestDecodeFolder";
            this.tbDestDecodeFolder.Size = new System.Drawing.Size(161, 49);
            this.tbDestDecodeFolder.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Destination Folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "File to Decode:";
            // 
            // btnBrowseFileToDecode
            // 
            this.btnBrowseFileToDecode.Location = new System.Drawing.Point(198, 52);
            this.btnBrowseFileToDecode.Name = "btnBrowseFileToDecode";
            this.btnBrowseFileToDecode.Size = new System.Drawing.Size(70, 49);
            this.btnBrowseFileToDecode.TabIndex = 6;
            this.btnBrowseFileToDecode.Text = "Browse";
            this.btnBrowseFileToDecode.UseVisualStyleBackColor = true;
            this.btnBrowseFileToDecode.Click += new System.EventHandler(this.btnBrowseFileToDecode_Click);
            // 
            // tbDecodeFile
            // 
            this.tbDecodeFile.Location = new System.Drawing.Point(20, 52);
            this.tbDecodeFile.Multiline = true;
            this.tbDecodeFile.Name = "tbDecodeFile";
            this.tbDecodeFile.Size = new System.Drawing.Size(161, 49);
            this.tbDecodeFile.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(295, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cypher System";
            // 
            // ofdChooseFile
            // 
            this.ofdChooseFile.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.rbRSA);
            this.groupBox1.Controls.Add(this.imageDialog);
            this.groupBox1.Controls.Add(this.rbRailFence);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 103);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encryption algorithm";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(19, 80);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(44, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "A51";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbRSA
            // 
            this.rbRSA.AutoSize = true;
            this.rbRSA.Location = new System.Drawing.Point(19, 47);
            this.rbRSA.Name = "rbRSA";
            this.rbRSA.Size = new System.Drawing.Size(47, 17);
            this.rbRSA.TabIndex = 1;
            this.rbRSA.Text = "RSA";
            this.rbRSA.UseVisualStyleBackColor = true;
            this.rbRSA.CheckedChanged += new System.EventHandler(this.rbRSA_CheckedChanged);
            // 
            // imageDialog
            // 
            this.imageDialog.Location = new System.Drawing.Point(84, 74);
            this.imageDialog.Name = "imageDialog";
            this.imageDialog.Size = new System.Drawing.Size(106, 23);
            this.imageDialog.TabIndex = 18;
            this.imageDialog.Text = "Load picture A51";
            this.imageDialog.UseVisualStyleBackColor = true;
            this.imageDialog.Click += new System.EventHandler(this.imageDialog_Click);
            // 
            // rbRailFence
            // 
            this.rbRailFence.AutoSize = true;
            this.rbRailFence.Checked = true;
            this.rbRailFence.Location = new System.Drawing.Point(19, 19);
            this.rbRailFence.Name = "rbRailFence";
            this.rbRailFence.Size = new System.Drawing.Size(59, 17);
            this.rbRailFence.TabIndex = 0;
            this.rbRailFence.TabStop = true;
            this.rbRailFence.Text = "Playfair";
            this.rbRailFence.UseVisualStyleBackColor = true;
            this.rbRailFence.CheckedChanged += new System.EventHandler(this.rbRailFence_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbShaOff);
            this.groupBox5.Controls.Add(this.rbShaOn);
            this.groupBox5.Location = new System.Drawing.Point(12, 183);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(190, 79);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "HASH-SHA256";
            // 
            // rbShaOff
            // 
            this.rbShaOff.AutoSize = true;
            this.rbShaOff.Location = new System.Drawing.Point(19, 47);
            this.rbShaOff.Name = "rbShaOff";
            this.rbShaOff.Size = new System.Drawing.Size(39, 17);
            this.rbShaOff.TabIndex = 1;
            this.rbShaOff.Text = "Off";
            this.rbShaOff.UseVisualStyleBackColor = true;
            // 
            // rbShaOn
            // 
            this.rbShaOn.AutoSize = true;
            this.rbShaOn.Checked = true;
            this.rbShaOn.Location = new System.Drawing.Point(19, 19);
            this.rbShaOn.Name = "rbShaOn";
            this.rbShaOn.Size = new System.Drawing.Size(39, 17);
            this.rbShaOn.TabIndex = 0;
            this.rbShaOn.TabStop = true;
            this.rbShaOn.Text = "On";
            this.rbShaOn.UseVisualStyleBackColor = true;
            this.rbShaOn.CheckedChanged += new System.EventHandler(this.rbShaOn_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cfbOff);
            this.groupBox6.Controls.Add(this.cfbOn);
            this.groupBox6.Location = new System.Drawing.Point(254, 183);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(190, 79);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "CFB";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // cfbOff
            // 
            this.cfbOff.AutoSize = true;
            this.cfbOff.Location = new System.Drawing.Point(19, 47);
            this.cfbOff.Name = "cfbOff";
            this.cfbOff.Size = new System.Drawing.Size(39, 17);
            this.cfbOff.TabIndex = 1;
            this.cfbOff.Text = "Off";
            this.cfbOff.UseVisualStyleBackColor = true;
            // 
            // cfbOn
            // 
            this.cfbOn.AutoSize = true;
            this.cfbOn.Checked = true;
            this.cfbOn.Location = new System.Drawing.Point(19, 19);
            this.cfbOn.Name = "cfbOn";
            this.cfbOn.Size = new System.Drawing.Size(39, 17);
            this.cfbOn.TabIndex = 0;
            this.cfbOn.TabStop = true;
            this.cfbOn.Text = "On";
            this.cfbOn.UseVisualStyleBackColor = true;
            this.cfbOn.CheckedChanged += new System.EventHandler(this.rbCFBOn_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(502, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 185);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(554, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 566);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCodeFilesFromDirectory;
        private System.Windows.Forms.Button btnDecodeFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnbrowseEncodePath;
        private System.Windows.Forms.TextBox tbEncodePath;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseFileToDecode;
        private System.Windows.Forms.TextBox tbDecodeFile;
        private System.Windows.Forms.Button btnBrowseDecodeDestFolder;
        private System.Windows.Forms.TextBox tbDestDecodeFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog fbdChooseFolder;
        private System.Windows.Forms.OpenFileDialog ofdChooseFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRSA;
        private System.Windows.Forms.RadioButton rbRailFence;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbShaOff;
        private System.Windows.Forms.RadioButton rbShaOn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton cfbOff;
        private System.Windows.Forms.RadioButton cfbOn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button imageDialog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}

