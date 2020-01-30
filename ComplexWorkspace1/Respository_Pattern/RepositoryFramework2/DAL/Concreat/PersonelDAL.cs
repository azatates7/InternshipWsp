using Respository_Pattern.RepositoryFramework3.Core;
using Respository_Pattern.RepositoryFramework3.DAL.Abstarct;
using Respository_Pattern.RepositoryFramework3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository_Pattern.RepositoryFramework3.DAL.Concreat
{ 
    public class PersonelDAL : BaseCRUDRepository<Personel, MyDBContext>, IPersonelDAL
    {
        public int PersonelCounter()
        {
            using (var context = new MyDBContext())
            {
                return context.Set<Personel>().ToList().Count;
            }
        }
    }
}