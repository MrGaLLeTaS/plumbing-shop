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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Icon = new Icon(@"Files/Pictures/icon.ico");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BackgroundImage = Image.FromFile(@"Files/Pictures/logo.jpg");
            Product[] a = new Product[100];
            int kol;
            String[] s = System.IO.File.ReadAllLines(@"Files\Ассортимент сантехники.txt");
            kol = 0;
            DataTable dt = new DataTable();

            dt.Columns.Add("Категория товара");
            dt.Columns.Add("Название товара");
            dt.Columns.Add("Цена товара");
            try
            {

                for (int i = 0; i < s.Length; i += 3)
                {
                    a[kol] = new Product(s[i], s[i + 1], System.Convert.ToInt32(s[i + 2]));
                    kol++;
                }
                for (int i = 0; i < kol; i++)
                {
                    DataRow st = dt.NewRow();
                    st[0] = a[i].Category;
                    st[1] = a[i].Name;
                    st[2] = a[i].Price;
                    dt.Rows.Add(st);
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = this.Size.Width / 3;
                dataGridView1.Columns[1].Width = this.Size.Width / 3;
                dataGridView1.Columns[2].Width = (this.Size.Width / 3);
            }
            catch
            {
                MessageBox.Show("Не верный путь к файлу!", "Ошибка программы!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\Режим работы.txt"))
            {
                file.WriteLine(0);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string[] u = System.IO.File.ReadAllLines(@"Files\Режим работы.txt");
            if (u[0] == "0")
            {
                MessageBox.Show("Для возможности заказать сантехнику вам нужно зарегистрироваться в программе или войти под своим логином", "Заказ сантехники", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form6 f = new Form6();
                f.Show();
            }
        }
    }
}
