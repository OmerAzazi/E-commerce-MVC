using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your DbSets (tables) here
        // public DbSet<YourEntity> YourEntities { get; set; } To Create a table in Db
        public DbSet <Category> Categories { get; set; }
    }
}
