using System;
using System.Collections.Generic;
using System.Linq;

namespace MobiBooking.Models.Repository
{
    public class UserRepository : IDefaultRepository<User>
    {
        private readonly BookingDbContext _db;

        public UserRepository(BookingDbContext db)
        {
            _db = db;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public User Get(int id)
        {
            return _db.Users.FirstOrDefault(c => c.Id == id);
        }

        public int Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

            return user.Id;
        }

        public int Update(int id, User item)
        {
            item.Id = id;
            _db.Users.Attach(item);

            return item.Id;
        }

        public int Delete(int id)
        {
            try
            {
                _db.Users.Remove(new User() { Id = id });
                _db.SaveChanges();
            }
            catch
            {
                if (_db.Users.Any(i => i.Id != id))
                {
                    throw new NullReferenceException();
                }
                else
                {
                    throw;
                }
            }

            return id;
        }
    }
}