using Microsoft.EntityFrameworkCore;
using WebApiSecurity.Models;

namespace WebApiSecurity.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opr) : base(opr)
        {

        }
        
        public DbSet<Security> SecurityItems { get; set; }
    }
} 