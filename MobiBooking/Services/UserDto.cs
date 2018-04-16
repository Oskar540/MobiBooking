using AutoMapper;
using MobiBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Services
{
    public class UserDto : Profile
    {
        public UserDto()
        {
            CreateMap<User, UserLogin>();
            CreateMap<UserLogin, User>();
        }
    }
}
