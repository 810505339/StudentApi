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
using Microsoft.AspNetCore.JsonPatch;

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
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents(Guid ClassId, [FromQuery]string Gender, string q)
        {
            if (!await _classRoomRepository.ClassRoomExists(ClassId))
            {
                return NotFound();
            }
            var Students = await _studentRepository.GetStudentAsync(ClassId, Gender, q);
            var StudentsDto = _mapper.Map<IEnumerable<StudentDto>>(Students);
            return Ok(StudentsDto);

        }
        [HttpGet("{StudentId}", Name = nameof(GetStudent))]
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

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(Guid ClassId, [FromBody] StudentAddDto studentAddDto)
        {
            if (!await _classRoomRepository.ClassRoomExists(ClassId))
            {
                return NotFound();
            }
            var enitity = _mapper.Map<Student>(studentAddDto);
            _studentRepository.AddStudent(ClassId, enitity);
            await _studentRepository.SaveAsync();
            var StudentDto = _mapper.Map<StudentDto>(enitity);
            return CreatedAtRoute(nameof(GetStudent), new { ClassId, StudentId = enitity.Id }, StudentDto);
        }
        [HttpPut("{StudentId}")]
        public async Task<IActionResult> UpdateStudent(Guid ClassId,Guid StudentId, [FromBody]updateStudentDto updateStudentDto)
        {
            if (! await _classRoomRepository.ClassRoomExists(ClassId))
            {
                return NotFound();
            }
            var Students = await _studentRepository.GetStudentAsync(ClassId, StudentId);
            if (Students == null)
            {
                return NotFound();
            }
            _mapper.Map(updateStudentDto, Students);
            _studentRepository.UpdateStudent(Students);
            await _studentRepository.SaveAsync();
            return NoContent();
        }
        /// <summary>
        /// 局部跟新
        /// </summary>
        [HttpPatch("{StudentId}")]
        public async Task<IActionResult> ParialyUpdateStudentForClass(Guid ClassId ,Guid StudentId ,JsonPatchDocument<updateStudentDto> jsonPatchDocument) 
        {
            if (!await _classRoomRepository.ClassRoomExists(ClassId))
            {
                return NotFound();
            }
            var Students = await _studentRepository.GetStudentAsync(ClassId, StudentId);
            if (Students == null)
            {
                return NotFound();
            }
            var dtoPatch = _mapper.Map<updateStudentDto>(Students);
            //需要处理验证错误
            jsonPatchDocument.ApplyTo(dtoPatch);
            //映射成数据库类型
            _mapper.Map(dtoPatch, Students);
            _studentRepository.UpdateStudent(Students);
            await _studentRepository.SaveAsync();
            return NoContent();
        }

    }
}
