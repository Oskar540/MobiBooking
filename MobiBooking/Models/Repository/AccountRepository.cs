using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MobiBooking.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models.Repository
{
    public class AccountRepository : IDefaultRepository<IdentityUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        public AccountRepository(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            ILogger logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public int Add(IdentityUser b)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IdentityUser Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentityUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(int id, IdentityUser b)
        {
            throw new NotImplementedException();
        }
    }
}
