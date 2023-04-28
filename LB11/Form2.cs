using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace LB11
{
    public partial class Form2 : Form
    {
        public Form1 form1;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //войти
        {
            using (StudentContext db = new StudentContext())
            {
                foreach (Student user in db.Students)
                {
                    if (textBox1.Text == user.Login && GetHash.GetHashString(textBox2.Text) == user.Password)
                    {
                        MessageBox.Show("Вход успешен!");
                        StudForm studForm = new StudForm();
                        studForm.label1.Text = user.Login;
                        studForm.Show();
                        studForm.form1 = this;
                        this.Visible = false;
                        return;
                    }
                }
                MessageBox.Show("Логин или пароль указан неверно!");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //создать акк
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //забыли пароль
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
