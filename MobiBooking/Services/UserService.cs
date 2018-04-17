using AutoMapper;
using MobiBooking.DTO;
using MobiBooking.Models;
using MobiBooking.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Services
{
    public class UserService : IDefaultRepository<UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IDefaultRepository<User> _repo;

        public UserService(IMapper mapper, IDefaultRepository<User> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        
        public IEnumerable<UserDto> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDto>>(_repo.GetAll());
        }

        public UserDto Get(int id)
        {
            return _mapper.Map<UserDto>(_repo.Get(id));
        }

        public int Add(UserDto user)
        {
            return _repo.Add(_mapper.Map<User>(user));
        }

        public int Update(int id, UserDto item)
        {
           return _repo.Update(id, _mapper.Map<User>(item));
        }

        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
