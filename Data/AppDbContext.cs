using Microsoft.EntityFrameworkCore;

namespace MyNewApp.Web.Data
{
    public class AppDbContext : DbContext
    {
        // Define your entity DbSet properties here

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
