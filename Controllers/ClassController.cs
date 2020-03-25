using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassRoomRepository _classRoomRepository;
        public ClassController(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository ?? throw new ArgumentNullException(nameof(classRoomRepository));
        }
        [HttpGet]
        public async Task<IActionResult> GetClassRooms()
        {
            var ClassRooms = await _classRoomRepository.GetClassRoomsAsync();
            return Ok(ClassRooms);
        }

        [HttpGet("{ClassRoomId}")]
        public async Task<IActionResult> GetClassRoom(Guid ClassRoomId)
        {
            var ClassRooms = await _classRoomRepository.GetClassRoomById(ClassRoomId);
            return Ok(ClassRooms);
        }
    }
}
