using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB11
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("DBConnection")
        {
            //  Database.Delete();
            // Database.Create();
        }
        public DbSet<Student> Students { get; set; }

    }
}
