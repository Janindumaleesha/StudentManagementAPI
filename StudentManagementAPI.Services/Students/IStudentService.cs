using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services.Students
{
    public interface IStudentService
    {
        public List<Student> GetAllStudents();
        public Student GetStudentById(int id);
        public Student CreateStudent(Student student);
        public Student UpdateStudent(int id, Student student);
        public Student DeleteStudent(int id);
    }
}
