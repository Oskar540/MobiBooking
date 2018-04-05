using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobiBooking.Models.Repository;
using System.Windows;

namespace MobiBooking.Models.DataManager
{
    public class UserManager : IDataRepository<User, int>
    {
        BookingDbContext ctx;

        public UserManager(BookingDbContext c)
        {
            ctx = c;
        }

        public User Get(int id)
        {
            var user = ctx.Users.FirstOrDefault(b => b.Id == id);
                return user;
        }
        public List<User> GetAll()
        {
            var users = ctx.Users.ToList();
            return users;
        }

        public int Add(User user)
        {
            ctx.Users.Add(user);
            int userID = ctx.SaveChanges();
            return userID;
        }
        public int Delete(int id)
        {
            int userID = 0;
            var user = ctx.Users.FirstOrDefault(b => b.Id == id);
            if (user != null)
            {
                ctx.Users.Remove(user);
                userID = ctx.SaveChanges();
            }
            return userID;
        }

        public int Update(int id, User item)
        {
            int userID = 0;
            var user = ctx.Users.Find(id);
            if (user != null)
            {
                user.login = item.login;
                user.password = item.password;
                user.email = item.email;
                user.name = item.name;
                user.lastname = item.lastname;
                user.bookedRooms = item.bookedRooms;

                userID = ctx.SaveChanges();
            }
            return userID;
        }
    }
}
