using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB11
{
    public class Student
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public DateTime DateB { get; set; }
        public string Group { get; set; }
        public string Faculty { get; set; }

        public Student()
        { }
        public Student(string Login, string Password, string Email, string name, string lastName, string phone, DateTime dateb, string Group, string Faculty)
        {
            this.Login = Login;
            this.Password = Password;
            this.Email = Email;
            this.Name = name;
            this.LastName = lastName;
            this.Phone = phone;
            this.DateB = dateb;
            this.Group = Group;
            this.Faculty = Faculty;
        }
    }

}
