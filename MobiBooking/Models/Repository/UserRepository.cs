using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models.Repository
{

    public class UserRepository : IUserRepository
    {

        public BookingDbContext db = new BookingDbContext(); //dodac parametr DbContextOptions do konstruktora


        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }
        public User GetByID(int id)
        {
            return db.Users.FirstOrDefault(c => c.Id == id);
        }

        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Update(int id, User item)
        {
            var user = db.Users.FirstOrDefault(c => c.Id == id);

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
            var user = db.Users.FirstOrDefault(c => c.Id == id);

            db.Users.Remove(user);
        }
    }
}
