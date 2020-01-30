using Respository_Pattern.RepositoryFramework.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository_Pattern.RepositoryFramework.Core
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> SelectAll(System.Linq.Expressions.Expression<Func<T, bool>> filter=null);
        T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        int Count(T entity);
    }
} 