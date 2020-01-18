using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDWorkspace
{
    public class DeleteItem
    {
        public void Delete(User usr)
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
