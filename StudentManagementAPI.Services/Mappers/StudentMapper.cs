﻿using AutoMapper;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services.Mappers
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();
        }
    }
}
