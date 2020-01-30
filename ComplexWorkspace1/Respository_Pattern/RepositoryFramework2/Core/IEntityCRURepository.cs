
using System;
using System.Collections.Generic;

namespace Respository_Pattern.RepositoryFramework3.Core
{
    public interface IEntityCRURepository<T> where T : class, IEntity2, new()
    {
        List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
    }
} 