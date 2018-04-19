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
        //private readonly UserManager<User> _manager;

        public UserRepository(BookingDbContext db/*, UserManager<User> manager*/)
        {
            _db = db;
            //_manager = manager;
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
            //AssignToRoles(user);

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

        //private void AssignToRoles(User user)
        //{
        //    if (user.Status == PropStatus.Admin)
        //    {
        //        _manager.AddToRoleAsync(user, "Admin");
        //    }
        //    else if (user.Status == PropStatus.User)
        //    {
        //        _manager.RemoveFromRoleAsync(user, "Admin");
        //        _manager.AddToRoleAsync(user, "User");
        //    }
        //}

    }
}