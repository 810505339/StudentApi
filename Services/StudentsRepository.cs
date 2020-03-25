using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Enitities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ScoolDbContext _scoolDbContext;
        public StudentRepository(ScoolDbContext scoolDbContext)
        {
            _scoolDbContext = scoolDbContext ?? throw new ArgumentNullException(nameof(scoolDbContext));
        }
        public void AddStudent(Guid classroomId, Student student)
        {
            if (classroomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(classroomId));
            }

            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            student.ClassId = classroomId;
            _scoolDbContext.Student.Add(student);
        }

        public void DeleteStudent(Student Student)
        {
            if (Student == null)
            {
                throw new ArgumentNullException(nameof(Student));
            }

            _scoolDbContext.Student.Remove(Student);
        }

        public async Task<Student> GetStudentAsync(Guid classroomId, Guid studentId)
        {
            if (classroomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(classroomId));
            }

            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(classroomId));
            }

            return await _scoolDbContext.Student.FirstOrDefaultAsync(x => x.ClassId == classroomId && x.Id == studentId);

        }

        public async Task<IEnumerable<Student>> GetStudentAsync(Guid classroomId)
        {
            if (classroomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(classroomId));
            }
            return await _scoolDbContext.Student.Where(x => x.ClassId == classroomId).ToListAsync();
        }

        public void UpdateStudent(Student Student)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> SaveAsync()
        {
            return await _scoolDbContext.SaveChangesAsync()>= 0;
        }
    }
}
