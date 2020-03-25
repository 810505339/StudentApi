using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public Guid ClassId { get; set; }
        public string NumberNo { get; set; }
        public string StudentName { get; set; }
        public string GenderDisplay { get; set; }
    }
}
