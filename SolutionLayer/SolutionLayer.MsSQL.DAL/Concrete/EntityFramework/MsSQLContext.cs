using SolutionLayer.MsSQL.DAL.Concrete.EntityFramework.Mapping;
using SolutionLayer.MsSQL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.Core.DAL.EntityFramework
{
    public class MsSQLContext:DbContext
    {
        public MsSQLContext()
        {
            Database.SetInitializer<MsSQLContext>(null);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Personel> Personels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}