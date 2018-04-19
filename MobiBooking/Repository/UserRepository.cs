using Microsoft.AspNetCore.Identity;
using MobiBooking.IdentityModels;
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
            //item.Id = id;
            //_db.Users.Attach(item);
            //_db.SaveChanges();

            //return item.Id;

            //AssignToRoles(item);

            var user = _db.Users.FirstOrDefault(c => c.Id == id);
            try
            {
                user.Login = item.Login;
                user.Password = item.Password;
                user.Name = item.Name;
                user.Lastname = item.Lastname;
                user.Email = item.Email;
                user.Status = item.Status;
                user.Reservations = item.Reservations;
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }

            return user.Id;
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
                    throw new Exception("User null, wrong parameter!");
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