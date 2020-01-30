using SolutionLayer.MsSQL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionLayer.MsSQL.DAL.Concrete.EntityFramework.Mapping
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo");
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName("UserId");
            Property(x => x.UserName).HasColumnName("UserName");
            Property(x => x.UserKey).HasColumnName("UserKey");
        }
    }
} 