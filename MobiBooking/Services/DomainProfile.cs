using AutoMapper;
using MobiBooking.DTO;
using MobiBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Services
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<RoomDto, Room>();
        }
    }
}
