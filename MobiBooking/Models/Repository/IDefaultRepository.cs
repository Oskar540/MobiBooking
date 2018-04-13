﻿using System.Collections.Generic;

namespace MobiBooking.Models.Repository
{
    public interface IDefaultRepository<Type>
    {
        IEnumerable<Type> GetAll();

        Type Get(int id);

        void Add(Type b);

        void Update(int id, Type b);

        void Delete(int id);
    }
}