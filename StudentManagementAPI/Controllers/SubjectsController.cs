using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services.Subjects;
using StudentManagementAPI.Services.ViewModels;

namespace StudentManagementAPI.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
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
            var student = _subjectService.GetSubjectById(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentMap = _mapper.Map<SubjectViewModel>(student);

            return Ok(studentMap);
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
            var subject = _subjectService.UpdateSubject(id, subjectMap);

            return NoContent();
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
