using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enitities;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClassCollectionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomRepository _classRoom;
        public ClassCollectionsController(IClassRoomRepository classRoom, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _classRoom = classRoom ?? throw new ArgumentNullException(nameof(classRoom));
        }
        [HttpGet("({guids})", Name =nameof(GetClassCollections))]
        public async Task<IActionResult> GetClassCollections([FromRoute]
        [ModelBinder(BinderType =typeof(ArrayModelBinder))]
        IEnumerable<Guid> guids)
        {
            if (guids == null)
            {
                return BadRequest();
            }
            var Enitites =await _classRoom.GetClassRoomsAsync(guids);

            if (guids.Count() != Enitites.Count())
            {
                return NotFound();
            }
            var dtoToTurn = _mapper.Map<IEnumerable<ClassRoomDto>>(Enitites);
            return Ok(dtoToTurn);

        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ClassRoomDto>>> CreateClassCollections(IEnumerable<ClassAddDto> ClassCollections)
        {
            var ClassEnitites = _mapper.Map<IEnumerable<ClassRoom>>(ClassCollections);
            foreach (var Class in ClassEnitites)
            {
                _classRoom.AddClassRoom(Class);
            }
            await _classRoom.SaveAsync();
            var ClassRoomDto = _mapper.Map<IEnumerable<ClassRoomDto>>(ClassEnitites);
            var idsString = string.Join(",", ClassRoomDto.Select(x => x.Id));
            return CreatedAtRoute(nameof(GetClassCollections), new { guids= idsString }, ClassRoomDto);
        }
    }
}
