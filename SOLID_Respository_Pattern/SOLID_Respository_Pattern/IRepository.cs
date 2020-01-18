using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Respository_Pattern
{
    public interface IRepository<T>
       where T : class, new()
    {
        IEnumerable<T> SelectAll();
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void deneme(T entity);
    }
} 