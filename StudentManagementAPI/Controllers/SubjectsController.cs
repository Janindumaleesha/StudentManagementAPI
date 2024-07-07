using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services.Students;
using StudentManagementAPI.Services.Subjects;
using StudentManagementAPI.Services.ViewModels;

namespace StudentManagementAPI.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectService subjectService, IStudentService studentService, IMapper mapper)
        {
            _subjectService = subjectService;
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<SubjectViewModel> CreateSubject(SubjectViewModel subjectViewModel)
        {
            var subjectMap = _mapper.Map<Subject>(subjectViewModel);
            var subject = _subjectService.CreateSubject(subjectMap);

            return Ok(subject);
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubjectViewModel>> GetAllSubject()
        {
            var subjects = _subjectService.GetAllSubjects();
            
            if (subjects == null)
            {
                return NotFound();
            }

            var subjectsMap = _mapper.Map<IEnumerable<SubjectViewModel>>(subjects);

            return Ok(subjectsMap);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubjectById(int id)
        {
            var subject = _subjectService.GetSubjectById(id);
            var students = _studentService.GetAllStudents();

            if (subject == null)
            {
                return NotFound();
            }

            //var students1 = new List<Student>();
            //var subjectViewModel = new List<SubjectViewModel>();

            foreach (var student in students)
            {
                if (student.SubjectId == id)
                {
                    subject.Students.Add(student);
                }
            }

            var subjectMap = _mapper.Map<SubjectViewModel>(subject);

            return Ok(subjectMap);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSubject(int id, SubjectViewModel subjectViewModel)
        {
            var getStudent = _subjectService.GetSubjectById(id);

            if (getStudent == null)
            {
                return NotFound();
            }

            var subjectMap = _mapper.Map<Subject>(subjectViewModel);
            _subjectService.UpdateSubject(getStudent.Id, getStudent);

            return Ok(subjectMap);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSubject(int id)
        {
            var getStudent = _subjectService.GetSubjectById(id);

            if (getStudent == null)
            {
                return NotFound();
            }

            _subjectService.DeleteSubject(id);

            return NoContent();
        }
    }
}
