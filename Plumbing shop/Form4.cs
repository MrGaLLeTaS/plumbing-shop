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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        Product[] a = new Product[100];
        int kol;

        private void Fill_table()
        {
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введите пароль!", "Ошибка программы", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                this.ActiveControl = textBox1; //на форме делаем текстбокс активным элементом
            }
            else
            {
                a[kol] = new Product(textBox1.Text, textBox2.Text, Convert.ToDouble(textBox3.Text));

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\Ассортимент сантехники.txt", true))
                {
                    file.WriteLine(a[kol].Category);
                    file.WriteLine(a[kol].Name);
                    file.WriteLine(a[kol].Price);
                    MessageBox.Show("Товар добавлен", "Редактирование данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                kol++;
            }
            dataGridView1.DataSource = new object();
            Fill_table();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Icon = new Icon(@"Files\Pictures\icon.ico");
            Fill_table();
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BackgroundImage = Image.FromFile(@"Files\Pictures\logo.jpg");
            this.ActiveControl = textBox1;
        }
    }
}
