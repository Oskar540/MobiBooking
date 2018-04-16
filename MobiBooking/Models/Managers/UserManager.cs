using MobiBooking.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MobiBooking.Models.DataManager
{
    public class UserManager : IDefaultRepository<User>
    {
        private BookingDbContext _ctx;

        public UserManager(BookingDbContext ctx)
        {
            _ctx = ctx;
        }

        public User Get(int id)
        {
            var user = _ctx.Users.FirstOrDefault(b => b.Id == id);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _ctx.Users;
            return users;
        }

        public int Add(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();

            return user.Id;
        }

        public int Delete(int id)
        {
            var user = _ctx.Users.FirstOrDefault(b => b.Id == id);
            if (user != null)
            {
                _ctx.Users.Remove(user);
                _ctx.SaveChanges();
            }
            return user.Id;
        }

        public int Update(int id, User item)
        {
            var user = _ctx.Users.FirstOrDefault(b => b.Id == id);

            if (user != null)
            {
                user.Login = item.Login;
                user.Password = item.Password;
                user.Email = item.Email;
                user.Name = item.Name;
                user.Lastname = item.Lastname;

                _ctx.SaveChanges();
            }

            return user.Id;
        }

        public User Create(User login)
        {
            throw new System.NotImplementedException();
        }
    }
}