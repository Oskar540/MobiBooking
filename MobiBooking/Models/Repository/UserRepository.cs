using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models.Repository
{

    public class UserRepository : IUserRepository
    {
        
        public UserRepository(BookingDbContext bookingDbContext)
        {
            _db = bookingDbContext;
        }

        private readonly BookingDbContext _db;

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }
        public User GetByID(int id)
        {

            return _db.Users.FirstOrDefault(c => c.Id == id);
        }

        public void Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void Update(int id, User item)
        {
            var user = _db.Users.FirstOrDefault(c => c.Id == id);

            if(item != null)
            {
                user.login = item.login;
                user.password = item.password;
                user.email = item.email;
                user.name = item.name;
                user.lastname = item.lastname;
            }
        }
        
        public void DeleteByID(int id)
        {
            var user = _db.Users.FirstOrDefault(c => c.Id == id);

            _db.Users.Remove(user);
        }
    }
}
