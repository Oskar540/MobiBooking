using System.Collections.Generic;

namespace MobiBooking.Models.Repository
{
    public interface IDefaultRepository<Type>
    {
        IEnumerable<Type> GetAll();

        Type Get(int id);

        int Add(Type b);

        int Update(int id, Type b);

        int Delete(int id);
    }
}