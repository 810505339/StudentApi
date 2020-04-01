using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ClassAddDto:IValidatableObject
    {
        [Display(Name="公司名称")]
        [Required(ErrorMessage ="{0}请填写班级名称:")]
        [MaxLength(100,ErrorMessage = "{0}最大长度不超过{1}")]
        public string ClassName { get; set; }
        [Display(Name = "简介")]
        [StringLength(500,MinimumLength =10,ErrorMessage ="{0}的范围{2}---{1}")]
        public string Introduction { get; set; }
        public ICollection<StudentAddDto> Students { get; set; } = new List<StudentAddDto>();
        /// <summary>
        /// 自定义验证
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ClassName.Contains("2222"))
            {
                yield return new ValidationResult("公司名字不能包含2222",new[] { nameof(ClassName) } );
            }
        }
    }
}
