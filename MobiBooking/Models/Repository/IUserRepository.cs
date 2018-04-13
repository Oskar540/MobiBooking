using System.Collections.Generic;

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