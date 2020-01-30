using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository_Pattern.RepositoryFramework3.Core
{
    public class BaseCRURepository<T, MyDBContext> : IEntityCRURepository<T>
        where T : class, IEntity2, new()
        where MyDBContext : DbContext, new()
    {

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            using (var context = new MyDBContext())
            {
                return filter == null
                    ? context.Set<T>().ToList()
                    : context.Set<T>().Where(filter).ToList();
            }
        }

        public T Add(T entity)
        {
            using (var context = new MyDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                return addedEntity.Entity;
            }
        }

        public T Update(T entity)
        {
            using (var context = new MyDBContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

                return updatedEntity.Entity;
            }
        }
    }
} 