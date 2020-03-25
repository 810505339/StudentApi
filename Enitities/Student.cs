using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Enitities
{
    [Table("student")]
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ClassId { get; set; }
        [Required]
        [MaxLength(10)]
        public string NumberNo { get; set; }
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public ClassRoom ClassRoom { get; set; }
    }
}
