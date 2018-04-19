using MobiBooking.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MobiBooking.Models.DataManager
{
    //public class UserManager : IDefaultRepository<User>
    //{
    //    private BookingDbContext _ctx;

    //    public UserManager(BookingDbContext ctx)
    //    {
    //        _ctx = ctx;
    //    }

    //    public User Get(int id)
    //    {
    //        return _ctx.Users.FirstOrDefault(b => b.Id == id);
    //    }

    //    public IEnumerable<User> GetAll()
    //    {
    //        return _ctx.Users;
    //    }

    //    public int Add(User user)
    //    {
    //        _ctx.Users.Add(user);
    //        _ctx.SaveChanges();

    //        return user.Id;
    //    }

    //    public int Delete(int id)
    //    {
    //        var user = _ctx.Users.FirstOrDefault(b => b.Id == id);
    //        if (user != null)
    //        {
    //            _ctx.Users.Remove(user);
    //            _ctx.SaveChanges();
    //        }
    //        return user.Id;
    //    }

    //    public int Update(int id, User item)
    //    {
    //        item.Id = id;
    //        _ctx.Users.Attach(item);

    //        return item.Id;
    //    }
    //}
}