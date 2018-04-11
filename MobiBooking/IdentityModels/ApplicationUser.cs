using MobiBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace MobiBooking.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        //public async Task<ClaimsIdentity>
        //GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    var userIdentity = await manager.CreateSecurityTokenAsync
        //            (this,
        //            DefaultAuthenticationTypes.ApplicationCookie);
        //    return userIdentity;
        //}

        
    }
}
