namespace EncryptFile
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
            this.btnSelFile = new System.Windows.Forms.Button();
            this.btnEncFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.openKeyFile = new System.Windows.Forms.OpenFileDialog();
            this.saveKeyFile = new System.Windows.Forms.SaveFileDialog();
            this.saveDecFile = new System.Windows.Forms.SaveFileDialog();
            this.saveEncFile = new System.Windows.Forms.SaveFileDialog();
            this.btnDecFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelFile
            // 
            this.btnSelFile.Location = new System.Drawing.Point(264, 10);
            this.btnSelFile.Name = "btnSelFile";
            this.btnSelFile.Size = new System.Drawing.Size(93, 23);
            this.btnSelFile.TabIndex = 0;
            this.btnSelFile.Text = "Select File";
            this.btnSelFile.UseVisualStyleBackColor = true;
            this.btnSelFile.Click += new System.EventHandler(this.btnSelFile_Click);
            // 
            // btnEncFile
            // 
            this.btnEncFile.Location = new System.Drawing.Point(264, 39);
            this.btnEncFile.Name = "btnEncFile";
            this.btnEncFile.Size = new System.Drawing.Size(93, 23);
            this.btnEncFile.TabIndex = 1;
            this.btnEncFile.Text = "Encrypt File";
            this.btnEncFile.UseVisualStyleBackColor = true;
            this.btnEncFile.Click += new System.EventHandler(this.btnEncFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(12, 13);
            this.txtFilePath.Multiline = true;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(246, 49);
            this.txtFilePath.TabIndex = 2;
            // 

            // OpenKeyFile
            // 
            this.openKeyFile.Filter = "Key File|*.key";
            // 

            // saveDecFile
            // 
            this.saveDecFile.Filter = "TXT File|*.txt";
            // 

            // saveKeyFile
            // 
            this.saveKeyFile.Filter = "Key File|*.key";
            // 
            // saveEncFile
            // 
            this.saveEncFile.Title = "Save Encrypted File";
            this.saveEncFile.Filter = "TXT File|*.txt";
            // 
            // btnDecFile
            // 
            this.btnDecFile.Location = new System.Drawing.Point(264, 68);
            this.btnDecFile.Name = "btnDecFile";
            this.btnDecFile.Size = new System.Drawing.Size(93, 23);
            this.btnDecFile.TabIndex = 5;
            this.btnDecFile.Text = "Decrypt File";
            this.btnDecFile.UseVisualStyleBackColor = true;
            this.btnDecFile.Click += new System.EventHandler(this.btnDecFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 181);
            this.Controls.Add(this.btnDecFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnEncFile);
            this.Controls.Add(this.btnSelFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "File Encrypter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelFile;
        private System.Windows.Forms.Button btnEncFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.OpenFileDialog openKeyFile;
        private System.Windows.Forms.SaveFileDialog saveDecFile;
        private System.Windows.Forms.SaveFileDialog saveKeyFile;
        private System.Windows.Forms.SaveFileDialog saveEncFile;
        private System.Windows.Forms.Button btnDecFile;
    }
}

