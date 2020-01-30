using Respository_Pattern.RepositoryFramework.Core;
using Respository_Pattern.RepositoryFramework.DAL.Abstract;
using Respository_Pattern.RepositoryFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository_Pattern.RepositoryFramework.DAL.Concreat
{
    public class CustomerDAL : BaseRepository<Customer, MyDBContext>, ICustomerDAL
    {

    }
}