using System;
using System.IO;
using System.Windows.Forms;

namespace Saugumas4
{
    public partial class Form1 : Form
    {
        public string mainfile = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\db.txt";
        //public string mainfilede = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\naujas.txt";
        string username = String.Empty;
        string password = String.Empty;
        Users users;

        public Form1()
        {
            InitializeComponent();
            //createfileandcheck();
           // this.users = users;
            //this.FormClosing += Form1_FormClosing;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prisijungimas f = new Prisijungimas(users);
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