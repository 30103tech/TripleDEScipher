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

            //����� ����, ��� ������������ �������, ��� �� ����� ��������� ���� � ����������� key
            if (saveKeyFile.ShowDialog() == DialogResult.OK)
            {
                // � ����� ����, ��� ������������ �������, ��� �� ����� ��������� ������������� ����
                if (saveEncFile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fsFileOut = File.Create(saveEncFile.FileName))
                    {
                        // ��������� ����������������� �����, ������� �� ���������� ������������
                        TripleDESCryptoServiceProvider cryptAlgorithm = new TripleDESCryptoServiceProvider();
                        using (CryptoStream csEncrypt = new CryptoStream(fsFileOut, cryptAlgorithm.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            csEncrypt.Write(File.ReadAllBytes(txtFilePath.Text), 0, (int)new FileInfo(txtFilePath.Text).Length);
                        }
                        // ���� ��������� ������ ������� ����� ����

                        //������� ���� � ����������� key
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

            //����� ����, ��� ������������� ���� ��� ������ ��� ��������
            if (openKeyFile.ShowDialog() == DialogResult.OK)
            {
                // ����� ����������� �����, ��� ������ ���� �������� ������������� ����
                if (saveDecFile.ShowDialog() == DialogResult.OK)
                {
                    // ������������� ����
                    using (FileStream fsFileIn = File.OpenRead(txtFilePath.Text))
                    {
                        // ����
                        using (FileStream fsKeyFile = File.OpenRead(openKeyFile.FileName))
                        {
                            // �������������� ����

                            // ����������� �������� ���������� � ���������� ���� �� ����� key
                            TripleDESCryptoServiceProvider cryptAlgorithm = new TripleDESCryptoServiceProvider();
                            BinaryReader brFile = new BinaryReader(fsKeyFile);
                            cryptAlgorithm.Key = brFile.ReadBytes(24);
                            cryptAlgorithm.IV = brFile.ReadBytes(8);

                            byte[] temp = new byte[new FileInfo(txtFilePath.Text).Length];
                            // ����������������� ����� ��������� ��������������� ����
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