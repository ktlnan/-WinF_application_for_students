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
    public partial class StudForm : Form
    {
        public Form2 form1;
        public StudForm()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "Login";
            dataGridView1.Columns[2].Name = "Password";
            dataGridView1.Columns[3].Name = "Email";
            dataGridView1.Columns[4].Name = "Group";
            dataGridView1.Columns[5].Name = "Name";
            dataGridView1.Columns[6].Name = "LastName";
            dataGridView1.Columns[7].Name = "DateTime";
            dataGridView1.Columns[8].Name = "Phone";
            dataGridView1.Columns[9].Name = "Faculty";
        }

        private void button1_Click(object sender, EventArgs e) //кнопка ок
        {
            using (StudentContext db = new StudentContext())
            {
                var studs = db.Students.ToList();
                foreach (var stud in studs)
                {
                    dataGridView1.Rows.Add(stud.Id, stud.Login, stud.Password, stud.Email, stud.Name, stud.LastName,
                        stud.Phone, stud.DateB, stud.Group, stud.Faculty);
                }
            }
        }
    }
}
