using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models.Repository
{
    public interface ITokenRepository<Type>
    {
        Type Create(Type login);
    }
}
