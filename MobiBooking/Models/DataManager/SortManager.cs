using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobiBooking.Models.Containers;
using MobiBooking.Models.Repository;

namespace MobiBooking.Models.DataManager
{
    public class SortManager : ISortingRepo<ListUserCont, string, bool>
    {
        ListUserCont obj;

        BookingDbContext ctx;

        public SortManager(BookingDbContext c)
        {
            ctx = c;
        }

        public ListUserCont OrderBy(ListUserCont t, string s, bool? d)
        {
            if (d != null)
            {
                if (d == true) return OrderBy(t, s, true);
            }

            if (s == "name") t.list.OrderBy(c => c.name);
            if (s == "lastname") t.list.OrderBy(c => c.lastname);

            return t;
        }

        public ListUserCont OrderBy(ListUserCont t, string s, bool d)
        {
            if (d == false) return OrderBy(t, s, null);

            if (s == "name") t.list.OrderByDescending(c => c.name);
            if (s == "lastname") t.list.OrderByDescending(c => c.lastname);

            return t;
        }
    }
}
