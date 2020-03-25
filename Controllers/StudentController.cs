using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enitities;
using WebApi.Services;
using AutoMapper;
using WebApi.Models;
using Microsoft.AspNetCore.Http;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Class/{ClassId}/[Controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _mapper;
        public StudentController(IStudentRepository studentRepository, IMapper mapper, IClassRoomRepository classRoomRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _classRoomRepository = classRoomRepository ?? throw new ArgumentNullException(nameof(classRoomRepository));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents(Guid ClassId,[FromQuery]string Gender,string q)
        {
            if (!await _classRoomRepository.ClassRoomExists(ClassId))
            {
                return NotFound();
            }
            var Students = await _studentRepository.GetStudentAsync(ClassId, Gender, q);
            var StudentsDto = _mapper.Map<IEnumerable<StudentDto>>(Students);
            return Ok(StudentsDto);

        }
        [HttpGet("{StudentId}")]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid ClassId, Guid StudentId)
        {
           
            if (!await _classRoomRepository.ClassRoomExists(ClassId))
            {
                return NotFound();
            }
            var Student = await _studentRepository.GetStudentAsync(ClassId, StudentId);
            if (Student == null)
            {
                return NotFound();
            }
            var StudentDto = _mapper.Map<StudentDto>(Student);
            return Ok(StudentDto);
        }
    }
}
