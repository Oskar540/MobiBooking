﻿using AutoMapper;
using MobiBooking.DTO;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Services
{
    public class RoomService : IDefaultRepository<RoomDto>
    {
        private readonly IDefaultRepository<Room> _repo;
        private readonly IMapper _mapper;

        public RoomService(IDefaultRepository<Room> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public int Add(RoomDto b)
        {
            return _repo.Add(_mapper.Map<Room>(b));
        }

        public int Delete(int id)
        {
            return _repo.Delete(id);
        }

        public RoomDto Get(int id)
        {
            return _mapper.Map<RoomDto>(_repo.Get(id));
        }

        public IEnumerable<RoomDto> GetAll()
        {
            return _mapper.Map<IEnumerable<RoomDto>>(_repo.GetAll());
        }

        public int Update(int id, RoomDto b)
        {
            return _repo.Update(id, _mapper.Map<Room>(b));
        }
    }
}
