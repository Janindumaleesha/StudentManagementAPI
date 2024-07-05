using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services.Subjects
{
    public interface ISubjectService
    {
        public List<Subject> GetAllSubjects();
        public Subject GetSubjectById(int id);
        public Subject CreateSubject(Subject subject);
        public Subject UpdateSubject(int id, Subject subject);
        public Subject DeleteSubject(int id);
    }
}
