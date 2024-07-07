using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services.Students;
using StudentManagementAPI.Services.ViewModels;

namespace StudentManagementAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<StudentViewModel> CreateStudent(StudentViewModel studentViewModel)
        {
            var studentMap = _mapper.Map<Student>(studentViewModel);
            var stundet = _studentService.CreateStudent(studentMap);
            return Ok(stundet);
        }

        [HttpGet]
        public ActionResult<ICollection<StudentViewModel>> GetAllStudent()
        {
            var getStudents = _studentService.GetAllStudents();

            if (getStudents == null)
            {
                return NotFound();
            }

            var studentMap = _mapper.Map<ICollection<StudentViewModel>>(getStudents);

            return Ok(studentMap);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var getStudent = _studentService.GetStudentById(id);

            if (getStudent == null)
            {
                return NotFound();
            }

            var studentMap = _mapper.Map<StudentViewModel>(getStudent);

            return Ok(studentMap);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentViewModel studentViewModel)
        {
            var getStudent = _studentService.GetStudentById(id);

            if (getStudent == null)
            {
                return NotFound();
            }

            var studentMap = _mapper.Map<Student>(studentViewModel);
            _studentService.UpdateStudent(getStudent.Id, studentMap);

            return Ok(studentMap);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var getStudent = _studentService.GetStudentById(id);

            if (getStudent == null)
            {
                return NotFound();
            }

            _studentService.DeleteStudent(id);

            return NoContent();
        }


    }
}
