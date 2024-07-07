using Microsoft.Data.SqlClient;
using StudentManagementAPI.DataAccess;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services.Students
{
    public class StudentService : IStudentService
    {
        // private readonly StudentManagementDbContext _context = new StudentManagementDbContext();
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-I46N7EU\\SQLEXPRESS;Initial Catalog=StudentManagermentDb;Integrated Security=True;Trust Server Certificate=True");
        public Student CreateStudent(Student student)
        {
            if (student != null)
            {
                SqlCommand cmd = new SqlCommand("CreateStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@SubjectId", student.SubjectId);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

            }
            return student;
        }

        public void DeleteStudent(int id)
        {
            SqlCommand cmd = new SqlCommand("DeleteStudent", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Student> GetAllStudents()
        {
            SqlDataAdapter sda = new SqlDataAdapter("GetAllStudent", con);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            List<Student> student = new List<Student>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Student student1 = new Student();
                    student1.Id = Convert.ToInt32(dataTable.Rows[i]["Id"]);
                    student1.FirstName = dataTable.Rows[i]["FirstName"].ToString();
                    student1.LastName = dataTable.Rows[i]["LastName"].ToString();
                    student1.Class = dataTable.Rows[i]["Class"].ToString();
                    student1.Gender = dataTable.Rows[i]["Gender"].ToString();
                    student1.SubjectId = Convert.ToInt32(dataTable.Rows[i]["SubjectId"]);
                    student.Add(student1);
                }
            }
            return student;
        }

        public Student GetStudentById(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("GetStudentById", con);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("Id", id);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            Student student = new Student();
            if (dataTable.Rows.Count > 0)
            {
                student.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                student.FirstName = dataTable.Rows[0]["FirstName"].ToString();
                student.LastName = dataTable.Rows[0]["LastName"].ToString();
                student.Class = dataTable.Rows[0]["Class"].ToString();
                student.Gender = dataTable.Rows[0]["Gender"].ToString();
                student.SubjectId = Convert.ToInt32(dataTable.Rows[0]["SubjectId"]);
            }
            return student;
        }

        public string UpdateStudent(int id, Student student)
        {
            string msg = string.Empty;
            if (student != null)
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@SubjectId", student.SubjectId);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    msg = "Successfully Updated!";
                }

            }
            return msg;
        }
    }
}
