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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        string log;

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"Files/Pictures/icon.ico");
            richTextBox1.ReadOnly= true;

            string[] u = System.IO.File.ReadAllLines(@"Files\Режим работы.txt");
            if (u[0] == "0")
            {
                this.Size = new Size(694, 396);
            }
            else
            {
                this.Size = new Size(812, 730);
                log = u[1];
            }
            this.ActiveControl = richTextBox2;

            try
            {
                String[] s = System.IO.File.ReadAllLines(@"Files/Отзывы.txt");

                for (int i = 0; i < s.Length; i++)
                {
                    richTextBox1.Text += s[i] + "\n";
                }
            } catch
            {
                MessageBox.Show("Ошибка открытия файла!", "Ошибка программы!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == " ")
                MessageBox.Show("Напишите отзыв, который вы хотите добавить!", "Ошибка программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\Отзывы.txt", true))
            {
                file.WriteLine(log);
                file.WriteLine(richTextBox2.Text);
                file.WriteLine();

                MessageBox.Show("Ваш отзыв добавлен!", "написание отзыва", MessageBoxButtons.OK, MessageBoxIcon.Information);

                richTextBox1.Text = "";
                String[] s = System.IO.File.ReadAllLines(@"Files\Отзывы.txt");
                for (int i = 0; i < s.Length; i++)
                {
                    richTextBox1.Text += s[i] + "\n";
                }
                richTextBox2.Text = "";
            }
        }
    }
}
