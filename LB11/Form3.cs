using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;


namespace LB11
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private string GeneratorPass()
        {
            string iPass = "";
            char[] arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z', 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z', 'A', 'E', 'U', 'Y', 'a', 'e', 'i', 'o', 'u', 'y' };
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                iPass = iPass + arr[rnd.Next(0, 57)].ToString();
            }
            return iPass;
        }
        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        private void button1_Click(object sender, EventArgs e) //отправка на почту
        {
            MailAddress from = new MailAddress("katelyn@internet.ru", "ktlnan");
            MailAddress to = new MailAddress(textBox1.Text);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Восстановление пароля";
            using (StudentContext db = new StudentContext())
            {
                foreach (Student user in db.Students)
                {
                    if (textBox1.Text == user.Email)
                    {
                        string newPassword = GeneratorPass();
                        m.Body = "<h1>Пароль: " + newPassword + "</h1>";
                        user.Password = GetHashString(newPassword);
                        MessageBox.Show("Пароль отправлен на почту");
                    }
                }
                db.SaveChanges();
            }
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("katelyn@internet.ru", "Gp7qPJ4NfmcRnH7XGh1D");
            smtp.EnableSsl = true;
            smtp.Send(m);
            this.Close();
        }
    }
}
