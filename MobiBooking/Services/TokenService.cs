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
    public class TokenService : ITokenRepository<UserDto>
    {
        private readonly IMapper _mapper;
        private readonly ITokenRepository<User> _repo;

        public TokenService(IMapper mapper, ITokenRepository<User> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public UserDto Create(UserDto user)
        {
            return _mapper.Map<UserDto>(_repo.Create(_mapper.Map<User>(user)));
        }

    }
}
