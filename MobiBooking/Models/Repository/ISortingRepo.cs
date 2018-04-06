using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models.Repository
{
    public interface ISortingRepo<T, Sorted, Desc> where T : MobiBooking.Models.Containers.ListUserCont
    {
        T OrderBy(T t, Sorted s, Desc d);
    }
}
