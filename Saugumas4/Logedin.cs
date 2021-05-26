using System;
using System.IO;
using System.Windows.Forms;

namespace Saugumas4
{
    public partial class Logedin : Form
    {
        public string file;
        private Users users;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            file = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\Vartotojai\\" + label1.Text + ".txt";
            if (File.Exists(file))
            {
                if (MessageBox.Show("You want to close and encrypt?", "Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    AES.FileEncrypt(file, "grazus");

                    File.Delete(file);
                    e.Cancel = false;
                }
                else if (MessageBox.Show("You want to close and encrypt?", "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        public Logedin(Users users)
        {
            InitializeComponent();
            this.users = users;
            label1.Text = users.User;
            label2.Text = users.Pass;

            this.FormClosing += Form1_FormClosing;
            File.Delete(file + ".aes");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string search = searchBox.Text;
                string totext = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\Vartotojai\\" + search + ".txt";
                string files = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\Vartotojai\\" + search + ".txt.aes";

                string path = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\Vartotojai";

                foreach (var file in Directory.GetFiles(path))
                {
                    Console.WriteLine(file);
                    if (file.Contains(search + ".txt.aes"))
                    {
                        AES.FileDecrypt(file, totext, "grazus");
                        using (StreamReader reader = new StreamReader(totext))
                        {
                            reader.ReadLine();
                            string pass = reader.ReadLine();
                            //Console.WriteLine(pass);
                            listBox1.Items.Add(file);
                            //listBox1.Items.Add(pass);
                        }
                    }
                }
                File.Delete(totext);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name;

            if (newpassBox.Text == againBox.Text)
            {
                if (listBox1.SelectedIndex != null)
                {
                    string filepath = listBox1.SelectedItem.ToString();
                    string filename = Path.ChangeExtension(filepath, null);
                    string corrext = Path.GetFileName(filename);

                    Console.WriteLine("pavadinimas " + corrext);
                    //string[] numbers = (filepath).Split('\\');
                    //char[] charsToTrim = { '.txt.aes'};
                    //listBox1.SelectedIndices.
                    //Console.WriteLine(numbers[12]);
                    //Path.GetFileNameWithoutExtension(filenumbername);
                    string totext = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\Vartotojai\\" + corrext;

                    AES.FileDecrypt(filepath, totext, "grazus");
                    using (StreamReader reader = new StreamReader(totext))
                    {
                        name = reader.ReadLine();
                        string passchanging = String.Empty;
                        reader.ReadLine();
                    }
                    string fileencrypt = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\Vartotojai\\" + corrext;
                    Console.WriteLine(name.ToString());

                    using (StreamWriter write = new StreamWriter(totext))
                    {
                        string username = name;
                        write.WriteLine(username);
                        write.WriteLine(againBox.Text);
                    }

                    AES.FileEncrypt(fileencrypt, "grazus");
                    File.Delete(totext);
                }
                else
                {
                    MessageBox.Show("select file");
                }
            }
            else
            {
                MessageBox.Show("pass muust be the same");
            }

            //Console.WriteLine(filepath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string name;
                string path = listBox1.SelectedItem.ToString();
                string filepath = Path.ChangeExtension(path, null);
                string filename = Path.GetFileName(filepath);

                Console.WriteLine("pavadinimas trinimas " + filename);

                string totext = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\Vartotojai\\" + filename;

                AES.FileDecrypt(path, totext, "grazus");
                using (StreamReader reader = new StreamReader(totext))
                {
                    name = reader.ReadLine();
                    string passchanging = String.Empty;
                    reader.ReadLine();
                }
                string fileencrypt = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\Vartotojai\\" + filename;
                Console.WriteLine(name.ToString());

                using (StreamWriter write = new StreamWriter(totext))
                {
                    string username = name;
                    write.WriteLine(username);
                    write.WriteLine("");
                }

                AES.FileEncrypt(fileencrypt, "grazus");
                File.Delete(totext);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != "")
            {
                string name;
                string filepath = listBox1.SelectedItem.ToString();
                string filename = Path.ChangeExtension(filepath, null);
                string corrext = Path.GetFileName(filename);

                Console.WriteLine("pavadinimas " + corrext);
                //string[] numbers = (filepath).Split('\\');
                //char[] charsToTrim = { '.txt.aes'};
                //listBox1.SelectedIndices.
                //Console.WriteLine(numbers[12]);
                //Path.GetFileNameWithoutExtension(filenumbername);
                string totext = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\Vartotojai\\" + corrext;

                AES.FileDecrypt(filepath, totext, "grazus");
                using (StreamReader reader = new StreamReader(totext))
                {
                    name = reader.ReadLine();
                    string passchanging = reader.ReadLine();
                    Clipboard.SetText(passchanging);
                }
                //AES.FileEncrypt();
                File.Delete(totext);

                MessageBox.Show("Slaptažodis nukopijuotas !");
            }
            else
                MessageBox.Show("Nepavyko nukopijuoti !");
        }

        public string savedpass;

        private void seatchBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != "")
            {
                string filepath = listBox1.SelectedItem.ToString();
                string filename = Path.ChangeExtension(filepath, null);
                string corrext = Path.GetFileName(filename);

                Console.WriteLine("pavadinimas " + corrext);
                //string[] numbers = (filepath).Split('\\');
                //char[] charsToTrim = { '.txt.aes'};
                //listBox1.SelectedIndices.
                //Console.WriteLine(numbers[12]);
                //Path.GetFileNameWithoutExtension(filenumbername);
                string totext = "C:\\Users\\Eimucio\\Desktop\\Studijos\\2 metai antras pusmetis\\Informacijos saugumas\\Saugumas4\\Saugumas4\\bin\\Debug\\Vartotojai\\" + corrext;

                AES.FileDecrypt(filepath, totext, "grazus");
                using (StreamReader reader = new StreamReader(totext))
                {
                    string passchanging = reader.ReadLine();
                    savedpass = reader.ReadLine();
                    //Clipboard.SetText(passchanging);
                }
                //AES.FileEncrypt();
                File.Delete(totext);

                MessageBox.Show("Slaptazodis issaugotas, bet nerodomas.");
            }
            else
                MessageBox.Show("Nepavyko nukopijuoti !");
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            showBox.Text = savedpass;
        }
    }
}