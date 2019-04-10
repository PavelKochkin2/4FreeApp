using Microsoft.EntityFrameworkCore;
using _4FreeApp.Models;

namespace _4FreeApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<FreeItem> FreeItems { get; set; }
    }
}