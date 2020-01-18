using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDWorkspace
{
    public class AddItem
    {
        public void Add(User usr)
        {
            try
            {
                using (MyDBContext context = new MyDBContext())
                { 
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
    }
}
