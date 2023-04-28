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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //очитка
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = " ";
            dateTimePicker1.Value = DateTime.Now;

        }

        private void button2_Click(object sender, EventArgs e) // регистрация
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)
               || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text)
               || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text))
            {

                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            using (StudentContext db = new StudentContext())
            {
                Student stud = new Student(textBox7.Text, GetHash.GetHashString(textBox8.Text), textBox6.Text, textBox1.Text, textBox2.Text,
                    textBox4.Text, dateTimePicker1.Value, textBox3.Text, textBox5.Text);
                db.Students.Add(stud);
                db.SaveChanges();
            }
            MessageBox.Show("Вы успешно зарегистрировались!");
            this.Close();

        }
    }
}
