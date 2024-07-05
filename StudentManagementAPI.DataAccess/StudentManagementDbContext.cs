using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.DataAccess
{
    public class StudentManagementDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = "Data Source=DESKTOP-I46N7EU\\SQLEXPRESS;Initial Catalog=StudentManagermentDb;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
