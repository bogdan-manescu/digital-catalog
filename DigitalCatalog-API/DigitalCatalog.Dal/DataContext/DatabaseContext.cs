using Microsoft.EntityFrameworkCore;
using DigitalCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCatalog.Dal.DataContext
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SqlExpress; Database=DigitalCatalog; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        public DatabaseContext()
        {
            
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        
        public DbSet<User> Users => Set<User>();
    }
}
