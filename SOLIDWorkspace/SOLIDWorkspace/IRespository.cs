using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDWorkspace
{
    public interface IRepository<T>
       where T : class, new()
    {
        IEnumerable<T> SelectAll();
        T SelectByID(object id);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }

} 