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
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly ITokenRepository<User> _repo;


        public UserService(IMapper mapper, ITokenRepository<User> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public UserDto Create(User user)
        {
            return _mapper.Map<UserDto>(_repo.Create(user));
        }
    }
}
