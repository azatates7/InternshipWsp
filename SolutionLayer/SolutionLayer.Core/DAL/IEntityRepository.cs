using SolutionLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.Core.DAL
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter=null);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity); 
    }
}
