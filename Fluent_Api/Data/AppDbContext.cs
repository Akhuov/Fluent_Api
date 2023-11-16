using Fluent_Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Fluent_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
