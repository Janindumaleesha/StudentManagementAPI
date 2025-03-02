﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Building { get; set; }

        [Required]
        [MaxLength(100)]
        public string HeadTeacher { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
