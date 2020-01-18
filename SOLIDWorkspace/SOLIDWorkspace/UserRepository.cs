using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDWorkspace
{
    public class UserRepository : BaseRepository<User, MyDBContext>
    {

        public User GetUser(int id)
        {
            return Get(filter: t => t.id == id);
        }

        public List<User> GetUserList(int id)
        {
            return GetList(filter: t => t.id == id);
        }

        public User AddUser(User usr)
        {
            return Add(usr);
        }

        public User UpdateUser(User usr)
        {
            return Update(usr);
        }

        public void DeleteUser(User usr)
        {
            Delete(usr);
        }
    }
}
