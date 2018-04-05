using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Models.Repository
{
    public interface IDataRepository<TEntity, U> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity Get(U id);
        int Add(TEntity b);
        int Update(U id, TEntity b);
        int Delete(U id);
    }
}
