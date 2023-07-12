using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plumbing_shop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Введите пароль!", "Ошибка  программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            String[] s = System.IO.File.ReadAllLines(@"Files\Пароль администратора.txt");

            if (textBox1.Text == s[0])
            {
                Form4 f = new Form4();
                f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не верный пароль!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"Files\Pictures\icon.ico");
            this.CenterToScreen();
            this.ActiveControl = textBox1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
