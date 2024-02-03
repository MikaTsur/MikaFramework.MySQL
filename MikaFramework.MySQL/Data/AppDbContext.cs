using Microsoft.EntityFrameworkCore;
using MikaFramework.MySQL.Models;

namespace MikaFramework.MySQL.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
