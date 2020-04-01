using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enitities;

namespace WebApi.Models
{
    public class updateStudentDto
    {

        [Display(Name = "学生编号")]
        [Required(ErrorMessage = "{0}请填写学生编号")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "{0}长度只能是{1}")]
        public string NumberNo { get; set; }
        [Display(Name = "姓")]
        [Required(ErrorMessage = "{0}请填写学生姓")]
        public string FirstName { get; set; }
        [Display(Name = "学生编号")]
        [Required(ErrorMessage = "{0}请填写学生名")]
        public string LastName { get; set; }
        [Display(Name = "学生性别")]
        public Gender Gender { get; set; }

    }
}
