using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.DataAccess;
using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Data;

namespace StudentManagementAPI.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        //private readonly StudentManagementDbContext _dbContext = new StudentManagementDbContext();
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-I46N7EU\\SQLEXPRESS;Initial Catalog=StudentManagermentDb;Integrated Security=True;Trust Server Certificate=True");
        public Subject CreateSubject(Subject subject)
        {
            if (subject != null)
            {
                SqlCommand cmd = new SqlCommand("CreateNewSubject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Id", subject.Id);
                cmd.Parameters.AddWithValue("@Name", subject.Name);
                cmd.Parameters.AddWithValue("@Building", subject.Building);
                cmd.Parameters.AddWithValue("@HeadTeacher", subject.HeadTeacher);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

            }
            return subject;
        }

        public string DeleteSubject(int id)
        {
            var msg = string.Empty;
            SqlCommand cmd = new SqlCommand("DeleteSubject", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                msg = "Deleted successfully!";
            }
            return msg;
        }

        public List<Subject> GetAllSubjects()
        {
            SqlDataAdapter sda = new SqlDataAdapter("GetAllSubject", con);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            List<Subject> subject = new List<Subject>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0;i < dataTable.Rows.Count;i++)
                {
                    Subject subject1 = new Subject();
                    subject1.Id = Convert.ToInt32(dataTable.Rows[i]["Id"]);
                    subject1.Name = dataTable.Rows[i]["Name"].ToString();
                    subject1.Building = dataTable.Rows[i]["Building"].ToString();
                    subject1.HeadTeacher = dataTable.Rows[i]["HeadTeacher"].ToString();
                    subject.Add(subject1);
                }
            }
            return subject;

        }

        public Subject GetSubjectById(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("GetSubjectById", con);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("Id", id);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            Subject subject1 = new Subject();
            if (dataTable.Rows.Count > 0)
            {
                subject1.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                subject1.Name = dataTable.Rows[0]["Name"].ToString();
                subject1.Building = dataTable.Rows[0]["Building"].ToString();
                subject1.HeadTeacher = dataTable.Rows[0]["HeadTeacher"].ToString();
            }
            return subject1;
        }

        public string UpdateSubject(int id, Subject subject)
        {
            var msg = string.Empty;
            if (subject != null)
            {
                SqlCommand cmd = new SqlCommand("UpdateSubject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", subject.Name);
                cmd.Parameters.AddWithValue("@Building", subject.Building);
                cmd.Parameters.AddWithValue("@HeadTeacher", subject.HeadTeacher);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    msg = "Updated successfully!";
                }
            }
            return msg;
        }
    }
}
