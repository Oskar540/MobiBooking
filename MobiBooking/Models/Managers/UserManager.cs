using MobiBooking.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MobiBooking.Models.DataManager
{
    public class UserManager : IDataRepository<User, int>
    {
        private BookingDbContext ctx;

        public UserManager(BookingDbContext c)
        {
            ctx = c;
        }

        public User Get(int id)
        {
            var user = ctx.Users.FirstOrDefault(b => b.Id == id);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = ctx.Users;
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
                user.Login = item.Login;
                user.Password = item.Password;
                user.Email = item.Email;
                user.Name = item.Name;
                user.Lastname = item.Lastname;
                //user.bookedRooms = item.bookedRooms;

                userID = ctx.SaveChanges();
            }
            return userID;
        }
    }
}