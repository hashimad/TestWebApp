using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Entities;

namespace TestWebApp.Domain.Context
{
    public class EFDbContext:DbContext
    {
        public EFDbContext():base("EFDbContext")
        {
                
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> User { get;  set; }
    }
}
