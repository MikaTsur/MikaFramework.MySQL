/*using Microsoft.EntityFrameworkCore;
using MikaFramework.MySQL.Models;

namespace MikaFramework.MySQL.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }


    }
}
*/

using Microsoft.EntityFrameworkCore;
using MikaFramework.MySQL.Models;

namespace MikaFramework.MySQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
