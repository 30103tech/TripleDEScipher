using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace EncryptFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnEncFile.Enabled = false;
            btnDecFile.Enabled = false;
        }

        private void btnSelFile_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFile.FileName;
                btnEncFile.Enabled = true;
                btnDecFile.Enabled = true;
            }
        }

        private void btnEncFile_Click(object sender, EventArgs e)
        {

            //После того, как пользователь выберет, где он хочет сохранить файл с расширением key
            if (saveKeyFile.ShowDialog() == DialogResult.OK)
            {
                // И после того, как пользователь выберет, где он хочет сохранить зашифрованный файл
                if (saveEncFile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fsFileOut = File.Create(saveEncFile.FileName))
                    {
                        // Поставщик криптографических услуг, который мы собираемся использовать
                        TripleDESCryptoServiceProvider cryptAlgorithm = new TripleDESCryptoServiceProvider();
                        using (CryptoStream csEncrypt = new CryptoStream(fsFileOut, cryptAlgorithm.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            csEncrypt.Write(File.ReadAllBytes(txtFilePath.Text), 0, (int)new FileInfo(txtFilePath.Text).Length);
                        }
                        // Этот создатель потока напишет новый файл

                        //Создать файл с расширением key
                        using (FileStream fsFileKey = File.Create(saveKeyFile.FileName))
                        {
                            BinaryWriter bwFile = new BinaryWriter(fsFileKey);
                            bwFile.Write(cryptAlgorithm.Key);
                            bwFile.Write(cryptAlgorithm.IV);
                            bwFile.Flush();
                            bwFile.Close();
                            btnEncFile.Enabled = false;
                            btnDecFile.Enabled = false;
                            txtFilePath.Text = "";
                        }
                    }
                }
            }
        }

        private void btnDecFile_Click(object sender, EventArgs e)
        {

            //После того, как зашифрованный файл был выбран для открытия
            if (openKeyFile.ShowDialog() == DialogResult.OK)
            {
                // После определения места, где должен быть сохранен дешифрованный файл
                if (saveDecFile.ShowDialog() == DialogResult.OK)
                {
                    // зашифрованный файл
                    using (FileStream fsFileIn = File.OpenRead(txtFilePath.Text))
                    {
                        // ключ
                        using (FileStream fsKeyFile = File.OpenRead(openKeyFile.FileName))
                        {
                            // расшифрованный файл

                            // Подготовьте алгоритм шифрования и прочитайте ключ из файла key
                            TripleDESCryptoServiceProvider cryptAlgorithm = new TripleDESCryptoServiceProvider();
                            BinaryReader brFile = new BinaryReader(fsKeyFile);
                            cryptAlgorithm.Key = brFile.ReadBytes(24);
                            cryptAlgorithm.IV = brFile.ReadBytes(8);

                            byte[] temp = new byte[new FileInfo(txtFilePath.Text).Length];
                            // Криптографический поток принимает незашифрованный файл
                            using (CryptoStream csEncrypt = new CryptoStream(fsFileIn, cryptAlgorithm.CreateDecryptor(), CryptoStreamMode.Read))
                            {
                                csEncrypt.Read(temp, 0, temp.Length);
                            }

                            File.WriteAllBytes(saveDecFile.FileName, temp);
                            btnEncFile.Enabled = false;
                            btnDecFile.Enabled = false;
                            txtFilePath.Text = "";
                        }
                    }
                }
            }
        }
        
    }
}