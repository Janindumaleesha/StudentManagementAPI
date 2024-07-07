using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services.ViewModels
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public string HeadTeacher { get; set; }
        public ICollection<StudentViewModel> Students { get; set; } = new List<StudentViewModel>();
    }
}
