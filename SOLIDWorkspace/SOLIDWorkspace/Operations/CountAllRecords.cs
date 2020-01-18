using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDWorkspace
{
    public class CountAllRecords
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
    }
}
