using Microsoft.EntityFrameworkCore;

namespace TestAPI.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Members> Members { get; set; }
    }
}
