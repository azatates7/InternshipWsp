using System;
using System.Data.Entity;

namespace EntityFrameworkWorkspace
{
    public class MyDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}