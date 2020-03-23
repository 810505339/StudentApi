using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enitities;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly ScoolDbContext _scoolDbContext;
        public ClassRoomRepository(ScoolDbContext scoolDbContext)
        {
            _scoolDbContext = scoolDbContext ?? throw new ArgumentNullException(nameof(scoolDbContext));
        }

        public void AddClassRoom(ClassRoom classRoom)
        {
            if (classRoom == null)
            {
                throw new ArgumentNullException(nameof(classRoom));
            }
            _scoolDbContext.ClassRooms.Add(classRoom);
        }

        public async Task<bool> ClassRoomExists(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(guid));
            }
            return await _scoolDbContext.ClassRooms.AnyAsync(x => x.Id == guid);
        }

        public void DeleteClassRoom(ClassRoom classRoom)
        {
            if (classRoom == null)
            {
                throw new ArgumentNullException(nameof(classRoom));
            }
            _scoolDbContext.ClassRooms.Remove(classRoom);
        }

        public async Task<ClassRoom> GetClassRoomById(Guid classroomId)
        {
            if (classroomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(classroomId));
            }

            return await _scoolDbContext.ClassRooms.FirstOrDefaultAsync(x => x.Id == classroomId);
        }

        public async Task<IEnumerable<ClassRoom>> GetClassRoomsAsync()
        {
            return await _scoolDbContext.ClassRooms.ToListAsync();
        }

        public async Task<IEnumerable<ClassRoom>> GetClassRoomsAsync(IEnumerable<Guid> classroomguIds)
        {
            if (classroomguIds == null)
            {
                throw new ArgumentNullException(nameof(classroomguIds));
            }
            return await _scoolDbContext.ClassRooms.Where(x => classroomguIds.Contains(x.Id)).OrderBy(x => x.Name).ToListAsync();
        }

        public void UpdateClassRoom(ClassRoom classRoom)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            return await _scoolDbContext.SaveChangesAsync() >= 0;
        }
    }
}
