using SolutionLayer.Core.DAL.EntityFramework;
using SolutionLayer.MsSQL.DAL.Abstaract;
using SolutionLayer.MsSQL.Entities.Concrete;

namespace SolutionLayer.MsSQL.DAL.Concrete
{
    public class EFUserDAL : EFRepositoryBase<User, MsSQLContext>, IUserDAL
    {
        
    }
}