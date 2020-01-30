using Respository_Pattern.RepositoryFramework3.Core;
using Respository_Pattern.RepositoryFramework3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository_Pattern.RepositoryFramework3.DAL.Abstarct
{
    public interface IPersonelDAL : IEntityCRUDRepository<Personel>
    {
    }
}
