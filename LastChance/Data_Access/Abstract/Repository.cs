using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Abstract
{
    public interface Repository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
