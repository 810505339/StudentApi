using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enitities;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;
using WebApi.DtoParameters;

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

        public async Task<IEnumerable<ClassRoom>> GetClassRoomsAsync(ClassDtoParameter classDtoParameter)
        {
            if (classDtoParameter == null)
            {
                throw new ArgumentNullException(nameof(classDtoParameter));
            }
            var item = _scoolDbContext.ClassRooms as IQueryable<ClassRoom>;
            /*搜索条件为空并名字为空*/
            if (string.IsNullOrWhiteSpace(classDtoParameter.ClassName) && string.IsNullOrWhiteSpace(classDtoParameter.Search))
            {
                return await item.ToListAsync();
            }
            if (!string.IsNullOrWhiteSpace(classDtoParameter.ClassName))
            {
                classDtoParameter.ClassName = classDtoParameter.ClassName.Trim();
                item = item.Where(x => x.Name == classDtoParameter.ClassName);
            }
            if (!string.IsNullOrWhiteSpace(classDtoParameter.Search))
            {
                classDtoParameter.Search = classDtoParameter.Search.Trim();
                item = item.Where(x => x.Name.Contains(classDtoParameter.Search) || x.Introduction.Contains(classDtoParameter.Search));
            }
            return await item.ToListAsync();

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
