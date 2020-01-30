using SolutionLayer.MsSQL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.MsSQL.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetData();
        User Update(User user);
        User Add(User user);
        void TransactionOperation(User usr1, User usr2);
    }
}