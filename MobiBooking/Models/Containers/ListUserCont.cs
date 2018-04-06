using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
