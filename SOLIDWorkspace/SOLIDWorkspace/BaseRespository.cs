using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDWorkspace
{
    public class BaseRepository<T, MyDBContext> : IRepository<T>
        where T : class, new()
        where MyDBContext : DbContext, new()
    {
        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            using (var context = new MyDBContext())
            {
                return filter == null
                    ? context.Set<T>().FirstOrDefault()
                    : context.Set<T>().FirstOrDefault(filter);
            }
        }

        public List<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
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

        public void Delete(T entity)
        {
            using (var context = new MyDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IEnumerable<T> SelectAll()
        {
            throw new NotImplementedException();
        }

        public T SelectByID(object id)
        {
            throw new NotImplementedException();
        }
    }
}
