using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEncryption
{
    public partial class EncryptionForm : Form
    {
        private string hash
        {
            get
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(passphrase));

                    var builder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        builder.Append(data[i].ToString("x2"));
                    }

                    return builder.ToString();
                }
            }
        }

        private string passphrase
        {
            get
            {
                return passphraseTextBox.Text;
            }
        }

        private string sourceFileName
        {
            get
            {
                return sourceTextBox.Text;
            }
            set
            {
                sourceTextBox.Text = value;
            }
        }

        private string destFileName
        {
            get
            {
                return destTextBox.Text;
            }
            set
            {
                destTextBox.Text = value;
            }
        }

        public EncryptionForm()
        {
            InitializeComponent();
        }

        private void EncryptionForm_Load(object sender, EventArgs e)
        {
            hashTextBox.Text = hash;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sourceButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sourceFileName = dialog.FileName;
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                File.WriteAllBytes(destFileName, new FileEncryption(hash).DecryptFile(sourceFileName));
                ShowSuccess("Decrypted file.");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void passphraseTextBox_TextChanged(object sender, EventArgs e)
        {
            hashTextBox.Text = hash;
        }

        private void destButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                destFileName = dialog.FileName;
            }
        }

        private bool ValidateForm()
        {
            if (passphraseTextBox.Text == "") {
                ShowError("Invalid passphrase.");
                return false;
            }

            if (!File.Exists(sourceFileName))
            {
                ShowError("Source does not exist.");
                return false;
            }

            if (destFileName == "")
            {
                ShowError("Invalid destination.");
                return false;
            }

            return true;
        }

        private void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "File Encryption", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccess(string successMessage)
        {
            MessageBox.Show(successMessage, "File Encryption", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                File.WriteAllBytes(destFileName, new FileEncryption(hash).EncryptFile(sourceFileName));
                ShowSuccess("Encrypted file.");
            }
        }
    }
}
