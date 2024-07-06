using Microsoft.Data.SqlClient;
using StudentManagementAPI.DataAccess;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly StudentManagementDbContext _context = new StudentManagementDbContext();
        public Student CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
