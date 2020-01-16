using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWorkspace
{
    public class UserDAL
    {

        public int CountRecords()
        {
            try
            {
                using (MyDBContext context = new MyDBContext())
                {
                    return context.Users.Count();
                } 
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public List<User> GetAll()
        {
            try
            {
                using (MyDBContext context = new MyDBContext())
                {
                    return context.Users.ToList();
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void AddUser (User usr)
        {
            try
            {
                using (MyDBContext context = new MyDBContext())
                {
                    //context.Users.Add(usr);
                    var entity = context.Entry(usr);
                    entity.State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateUser(User usr)
        {
            try
            {
                using (MyDBContext context = new MyDBContext())
                {
                    var entity = context.Entry(usr);
                    entity.State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteUser(User usr)
        {
            try
            {
                using (MyDBContext context = new MyDBContext())
                {
                    var entity = context.Entry(usr);
                    entity.State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }
    } 
}
