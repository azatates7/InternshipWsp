using SolutionLayer.Core.DAL;
using SolutionLayer.MsSQL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.MsSQL.DAL.Abstaract
{
    public interface IUserDAL : IEntityRepository<User>
    {
        
    }
}