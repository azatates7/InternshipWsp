using SolutionLayer.Core.DAL.EntityFramework;
using SolutionLayer.MsSQL.DAL.Abstaract;
using SolutionLayer.MsSQL.Entities.ComplexTypes;
using SolutionLayer.MsSQL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.MsSQL.DAL.Concrete
{
    public class EFPersonelDAL : EFRepositoryBase<Personel, MsSQLContext>, IPersonelDAL
    {
        public List<UserDetails> GetUserDetais()
        {
            using (var context = new MsSQLContext()){
                var rs = from p in context.Users
                         join c in context.Personels on p.UserId equals c.PersonelId
                         select new UserDetails
                         {
                             UserId = p.UserId,
                             UserName = p.UserName,
                             PersonelName = c.PersonelName
                         };
                return rs.ToList();
            } 
        }
    }
} 