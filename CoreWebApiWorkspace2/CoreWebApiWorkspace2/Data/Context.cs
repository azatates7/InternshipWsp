using CoreWebApiWorkspace2.Models;
using Microsoft.EntityFrameworkCore; 

namespace CoreWebApiWorkspace2.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opr) : base(opr)
        {

        }

        public DbSet<User> Users { get; set; }

    }
} 