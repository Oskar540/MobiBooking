using Microsoft.AspNetCore.Identity;

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