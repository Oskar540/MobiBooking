using System.Collections.Generic;

namespace MobiBooking.Models.Containers
{
    public class ListUserCont
    {
        public List<User> list;

        public ListUserCont(List<User> obj)
        {
            list = obj;
        }
    }
}