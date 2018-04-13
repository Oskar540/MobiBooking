using System;
using System.Collections.Generic;
using System.Linq;

namespace MobiBooking.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingDbContext _db;

        public UserRepository(BookingDbContext bookingDbContext)
        {
            _db = bookingDbContext;
        }

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
            item.Id = id;
            _db.Users.Attach(item);

            //var user = _db.Users.FirstOrDefault(c => c.Id == id);
            //if (user == null) return;

            //if(item != null)
            //{
            //    user.login = item.login;
            //    user.password = item.password;
            //    user.email = item.email;
            //    user.name = item.name;
            //    user.lastname = item.lastname;
            //}
        }

        public void DeleteByID(int id)
        {
            try
            {
                _db.Users.Remove(new User() { Id = id });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (_db.Users.Any(i => i.Id != id))
                {
                    throw new NullReferenceException();
                }
                else
                {
                    throw ex;
                }
            }

            //var user = _db.Users.FirstOrDefault(c => c.Id == id);
            //_db.Users.Remove(user);

            //User user = new User() { Id = id };
            //_db.Users.Attach(user);
            //_db.Users.Remove(user);
            //_db.SaveChanges();
        }
    }
}