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

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Faculty> Faculties => Set<Faculty>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Score> Scores => Set<Score>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();
        public DbSet<Article> Articles => Set<Article>();
    }
}
