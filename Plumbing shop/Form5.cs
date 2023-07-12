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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        Buyer[] a = new Buyer[1000];
        int q;
        bool p;

        private void Form5_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Icon = new Icon(@"Files\Pictures\icon.ico");
            this.ActiveControl = textBox1;
            p = false;
            try
            {
                String[] s = System.IO.File.ReadAllLines(@"Files\Учетные записи.txt");
                q = 0;
                for (int i = 0; i < s.Length; i += 2)
                {
                    a[q] = new Buyer(s[i], s[i + 1]);
                    q++;
                }
            } catch
            {
                MessageBox.Show("Ошибка чтения файла!", "Ошибка программы!", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Введите данные полностью!", "Создание учетной записи!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = textBox1;//на форме делаем текстбокс активным  элементом
                }
                else
                {
                    bool x = false;
                    for (int i = 0; i < q; i++)
                        if (textBox1.Text == a[i].Login)
                            x = true;
                    if (x)
                    {
                        MessageBox.Show("Такой логин уже занят!", "Создание учетной записи!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.ActiveControl = textBox1;//на форме делаем текстбокс активным  элементом 

                    }
                    else
                    {
                        if (textBox2.Text != textBox3.Text)
                        {
                            MessageBox.Show("Пароли должны совпадать!", "Создание учетной записи!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.ActiveControl = textBox1;//на форме делаем текстбокс активным  элементом 
                        }
                        else
                        {
                            a[q] = new Buyer(textBox1.Text, textBox2.Text);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\Учетные записи.txt", true))
                            {
                                file.WriteLine(a[q].Login);
                                file.WriteLine(a[q].Pass);
                            }
                            q++;
                            MessageBox.Show("Регистрация прошла успешно!", "Создание учетной записи!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\Режим работы.txt"))
                            {
                                file.WriteLine(1);//Режим Зарегистрированного пользователя
                                file.WriteLine(0);//начальная сумма покупки 
                                file.WriteLine(textBox1.Text);//записываем логин третьей  строкой, для отзыва 
                            }
                            p = true; //включаем режем Зарегистрированного пользователя
                            this.Close();//форма после регистрации закрывается и посетитель опять попадает на 1 форму
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка регистрации!", "Создание учетной записи!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!p)
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\Режим работы.txt"))
                {
                    file.WriteLine(0);//Режим пользователя, при закрытии окна регистрации без  регистрации в файле записываем 0  
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Введите данные полностью!", "Ошибка входа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.ActiveControl = textBox6;
            bool p2 = false;
            for (int i = 0; i < q; i++)
            {
                p2 = true;
                bool p1 = false;
                if (textBox6.Text == a[i].Pass)
                {
                    p1 = true;
                }
                if (!p1)
                {
                    MessageBox.Show("Пароль неверный!", "Ошибка входа в программу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox5.Text = "";
                    textBox6.Text = "";
                    this.ActiveControl = textBox5;
                }
                else
                {
                    MessageBox.Show("Добро пожаловать, " + textBox5.Text + "!", "вход в программу", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Files\Режим работы.txt"))
                    {
                        file.WriteLine(1);
                        file.WriteLine(textBox5.Text);
                    }
                    p = true;
                    this.Close();
                }
            }
            if (!p2)
            {
                MessageBox.Show("Вы не зарегистрированы!", "Ошибка входа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Text = "";
                textBox6.Text = "";
                this.ActiveControl= textBox5;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

