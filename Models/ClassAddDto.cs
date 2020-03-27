using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ClassAddDto
    {
        public string ClassName { get; set; }
        public string Introduction { get; set; }
        public ICollection<StudentAddDto> Students { get; set; } = new List<StudentAddDto>();
    }
}
