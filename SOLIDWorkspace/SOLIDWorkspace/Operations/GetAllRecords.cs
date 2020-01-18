using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDWorkspace
{
    public class GetAllRecords
    {
        public List<User> GetRecords()
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
    }
}
