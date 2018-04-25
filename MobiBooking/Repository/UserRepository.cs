using MobiBooking.Exceptions;
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
            return _db.Users.OrderBy(c => c.Lastname);
        }

        public User Get(int id)
        {
            var user = _db.Users.FirstOrDefault(c => c.Id == id);
            user.ActualizeWeekMonthStatistics(user);
            if (user == null)
            {
                throw new HttpResponseException(404, "Can't find user with this identifier!");
            }

            return user;
        }

        public int Add(User user)
        {
            if(user == null)
            {
                throw new HttpResponseException(400, "Invalid sended data!");
            }
            _db.Users.Add(user);
            _db.SaveChanges();

            return user.Id;
        }

        public int Update(int id, User item)
        {
            var user = _db.Users.FirstOrDefault(c => c.Id == id);
            if(user == null)
            {
                throw new HttpResponseException(404, "Can't find user with this identifier!");
            }
            try
            {
                user.Login = item.Login;
                user.Password = item.Password;
                user.Name = item.Name;
                user.Lastname = item.Lastname;
                user.Email = item.Email;
                user.Status = item.Status;
                _db.SaveChanges();
            }
            catch
            {
                throw new HttpResponseException(400, "Invalid sended data!");
            }

            return user.Id;
        }

        public int Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(c => c.Id == id);
            if(user == null)
            {
                throw new HttpResponseException(404, "Can't find user with this identifier!");
            }
            _db.Users.Remove(user);
            _db.SaveChanges();
            
            return id;
        }
    }
}