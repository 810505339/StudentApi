using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enitities;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Class/{ClassId}/[Controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        public async Task<ActionResult<IEnumerable<Student>>> GetStudents(Guid ClassId)
        { 
        
        }
    }
}
