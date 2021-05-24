using System;
using System.IO;
using System.Windows.Forms;

namespace Saugumas4
{
    public partial class Form1 : Form
    {
        public string mainfile = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\db.txt";
        //public string mainfilede = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\naujas.txt";

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("You want to close and encrypt?", "Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                AES.FileEncrypt(mainfile, "grazus");
                
                File.Delete(mainfile);
                e.Cancel = false;
                
            }
            else if (MessageBox.Show("You want to close and encrypt?", "Close", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public Form1()
        {
            InitializeComponent();
            createfileandcheck();

            this.FormClosing += Form1_FormClosing;
        }

        public void createfileandcheck()
        {
            try
            {
                if (File.Exists(mainfile + ".aes"))
                {
                    AES.FileDecrypt(mainfile + ".aes", mainfile, "grazus");
                    File.Delete(mainfile+".aes");
                }
                else
                {
                    StreamWriter writer = new StreamWriter(mainfile);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prisijungimas f = new Prisijungimas();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();
            //f1.Hide();
            Registracija f = new Registracija();
            f.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}