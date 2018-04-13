using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByID(int id);
        void Add(User t);
        void Update(int id, User t);
        void DeleteByID(int id);
    }
}
