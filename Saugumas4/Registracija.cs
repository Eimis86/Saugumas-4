using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saugumas4;
using System.Security.Cryptography;

namespace Saugumas4
{
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string confirmpass = textBox3.Text;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string file = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\vartotojai\\" + username + ".txt";
                Console.WriteLine(file);
                using (StreamWriter write = new StreamWriter(file))
                {
                    write.WriteLine(username);
                    write.WriteLine(password);
                    write.WriteLine(confirmpass);
                }
                MessageBox.Show("AES");
                //byte[] encripted = Encrypt(username ,aes.Key ,aes.IV); 
            }
            else
            {
                MessageBox.Show("All fields must be written");
            }
        }
        public static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            // Create a new AesManaged.
            using (AesManaged aes = new AesManaged())
            {
                // Create encryptor
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                // Create MemoryStream
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream
                    // to encrypt
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data
            return encrypted;
        }
        //-------------------------------------------------------------------------------------------------
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
