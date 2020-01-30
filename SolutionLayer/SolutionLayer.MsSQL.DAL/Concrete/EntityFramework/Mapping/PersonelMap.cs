using SolutionLayer.MsSQL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.MsSQL.DAL.Concrete.EntityFramework.Mapping
{
    public class PersonelMap : EntityTypeConfiguration<Personel>
    {
        public PersonelMap()
        {
            ToTable(@"Personels", @"dbo");
            HasKey(x => x.PersonelId);

            Property(x => x.PersonelId).HasColumnName("PersonelId");
            Property(x => x.PersonelName).HasColumnName("PersonelName");
            Property(x => x.PersonelDepartment).HasColumnName("PersonelDepartment");
        }
    }
} 