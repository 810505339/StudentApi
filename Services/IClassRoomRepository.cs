using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DtoParameters;
using WebApi.Enitities;

namespace WebApi.Services
{
    public interface IClassRoomRepository
    {
        Task<IEnumerable<ClassRoom>> GetClassRoomsAsync(ClassDtoParameter classDtoParameter);
        Task<ClassRoom> GetClassRoomById(Guid classroomId);
        Task<IEnumerable<ClassRoom>> GetClassRoomsAsync(IEnumerable<Guid> classroomguIds);

        void AddClassRoom(ClassRoom classRoom);
        void DeleteClassRoom(ClassRoom classRoom);
        void UpdateClassRoom(ClassRoom classRoom);
        Task<bool> ClassRoomExists(Guid guid);
      
    }
}
