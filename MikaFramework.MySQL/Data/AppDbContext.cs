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

            //modelBuilder.Entity<Department>()
                //.HasOne(d => d.Manager)
                //.WithOne(e => e.Department)
                //.HasForeignKey<Employee>(e => e.DepartmentID)
                //.IsRequired(false); // Adjust this based on your requirements

            // Other configurations if needed

            // Example: modelBuilder.Entity<YourEntity>().Property(e => e.YourProperty).IsRequired();
        }
    }
}
