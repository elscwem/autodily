using Microsoft.EntityFrameworkCore;
using E_shopAutodily.Models;

namespace E_shopAutodily.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
