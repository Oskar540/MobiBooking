using AutoMapper;
using MobiBooking.DTO;
using MobiBooking.Exceptions;
using MobiBooking.Models;
using MobiBooking.Models.Repository;

namespace MobiBooking.Services
{
    public class TokenService : ITokenRepository<UserDto>
    {
        private readonly IMapper _mapper;
        private readonly ITokenRepository<User> _repo;

        public TokenService(IMapper mapper, ITokenRepository<User> repo)
        {
            _repo = repo ?? throw new HttpResponseException(503, "Issue with connect to repository");
            _mapper = mapper ?? throw new HttpResponseException(503, "Issue with connect to automapper");
        }

        public UserDto Create(UserDto user)
        {
            return _mapper.Map<UserDto>(_repo.Create(_mapper.Map<User>(user)));
        }
    }
}