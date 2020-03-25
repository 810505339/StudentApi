using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enitities;

namespace WebApi.Services
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentAsync(Guid classroomId,string Gender,string q);
        Task<Student> GetStudentAsync(Guid classroomId, Guid studentId);
        void AddStudent(Guid classroomId, Student student);
        void DeleteStudent(Student Student);
        void UpdateStudent(Student Student);
    }
}
