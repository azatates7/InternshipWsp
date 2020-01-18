using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDWorkspace
{
    public class UpdateItem
    {
        public void Update(User usr)
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
    }
}
