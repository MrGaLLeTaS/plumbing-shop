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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        Product[] a = new Product[100];
        int kol;
        double Sum;

        private void Form6_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Icon = new Icon(@"Files\Pictures\icon.ico");
            Sum = 0;
            String[] s = System.IO.File.ReadAllLines(@"Files\Ассортимент сантехники.txt");
            kol = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("Категория товара");
            dt.Columns.Add("Название товара"); dt.Columns.Add("Цена товара");  
            try
            {
                for (int i = 0; i < s.Length; i += 3)
                {  
                    a[kol] = new Product(s[i], s[i + 1], System.Convert.ToDouble(s[i + 2]));
                    kol++;
                }
            for (int i = 0; i < kol; i++)
            {
                DataRow st = dt.NewRow();
                st[0] = a[i].Category;
                st[1]  = a[i].Name;
                st[2] = a[i].Price;
                dt.Rows.Add(st);
            }  
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = this.Size.Width / 3;
                dataGridView1.Columns[1].Width = this.Size.Width / 3; ; dataGridView1.Columns[2].Width = (this.Size.Width / 3);
            }
            catch
            {
                MessageBox.Show("Не верный путь к файлу!", "Ошибка программы!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            comboBox1.Items.Add(a[0].Category); 
            for (int i = 1; i < kol; i++) 
            {  
                bool b = false;
                for (int j = 0; j < i; j++) 
                    if (a[j].Category == a[i].Category) 
                      b = true;
                if (!b)
                {
                    comboBox1.Items.Add(a[i].Category);
                }
            }
            comboBox1.Items.Add("Все");
            comboBox1.Text = "Все";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Категория товара");
            dt.Columns.Add("Название товара");
            dt.Columns.Add("Цена товара"); 
            for (int i = 0; i < kol; i++)
            {
                DataRow st = dt.NewRow();
                if (comboBox1.Text == "Все")  
                {
                    st[0] = a[i].Category;
                    st[1] = a[i].Name;
                    st[2] = a[i].Price;
                    dt.Rows.Add(st); 
                }  
                else if (comboBox1.Text == a[i].Category)
                {
                        st[0] = a[i].Category;
                        st[1] = a[i].Name;
                        st[2] = a[i].Price;
                        dt.Rows.Add(st);
                } 
            }  
        dataGridView1.DataSource = dt;
        dataGridView1.Columns[0].Width = this.Size.Width / 3;
        dataGridView1.Columns[1].Width = this.Size.Width / 3;
        dataGridView1.Columns[2].Width = (this.Size.Width / 3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sum = 0;
            label5.Text = "Стоимость заказа:";
            richTextBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\Заказ.txt", true))//откріли файл для дозаписи
            {
                file.WriteLine(richTextBox1.Text);//записали заказанные товары
                file.WriteLine("Стоимость: " + Sum + " рублей");//записали стоимость заказа
            }
            Sum = 0;
            label5.Text = "Стоимость заказа:";
            richTextBox1.Text = "";
            comboBox1.Text = "Все";
            Form7 f = new Form7();//переход на форму заказа
            f.Show();
        }
    }
}
