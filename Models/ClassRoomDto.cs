using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ClassRoomDto
    {
       
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public string Introduction { get; set; }

        
    }
}
