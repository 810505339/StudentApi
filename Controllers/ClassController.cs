﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;
using WebApi.Models;
using WebApi.DtoParameters;
using WebApi.Enitities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _Mapper;
        public ClassController(IClassRoomRepository classRoomRepository, IMapper Mapper)
        {
            _classRoomRepository = classRoomRepository ?? throw new ArgumentNullException(nameof(classRoomRepository));
            _Mapper = Mapper ?? throw new ArgumentNullException(nameof(Mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassRoomDto>>> GetClassRooms([FromQuery]ClassDtoParameter classDtoParameter)
        {
            var ClassRooms = await _classRoomRepository.GetClassRoomsAsync(classDtoParameter);
            var ClassRoomDto = _Mapper.Map<IEnumerable<ClassRoomDto>>(ClassRooms);
            return Ok(ClassRoomDto);
        }

        [HttpGet("{ClassRoomId}",Name =nameof(GetClassRoom))]
        public async Task<ActionResult<ClassRoomDto>> GetClassRoom(Guid ClassRoomId)
        {
            var ClassRoom = await _classRoomRepository.GetClassRoomById(ClassRoomId);
            if (ClassRoom == null)
            {
                return NotFound();
            }
            var ClassRoomDto = _Mapper.Map<ClassRoomDto>(ClassRoom);
            return Ok(ClassRoomDto);
        }
        [HttpPost]
        public async Task<ActionResult<ClassRoomDto>> CreateClass([FromBody]ClassAddDto Class)
        {
            var enitite = _Mapper.Map<ClassRoom>(Class);
            _classRoomRepository.AddClassRoom(enitite);
            await _classRoomRepository.SaveAsync();
            var ClassDto = _Mapper.Map<ClassRoomDto>(enitite);
            return CreatedAtRoute(nameof(GetClassRoom), new { ClassRoomId = enitite.Id },ClassDto);
        }

    }
}
