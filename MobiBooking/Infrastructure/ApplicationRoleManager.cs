using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MobiBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Infrastructure
{
    //public class ApplicationRoleManager : RoleManager<IdentityRole>
    //{
    //    public ApplicationRoleManager(IRoleStore<IdentityRole> roleStore)
    //    {

    //    }

    //    public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
    //    {
    //        var appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<BookingDbContext>()));

    //        return appRoleManager;
    //    }
    //}
}
