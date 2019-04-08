using Microsoft.EntityFrameworkCore;
using _4FreeApp.Models;

namespace _4FreeApp.Data
{
    public class FreeItemContext : DbContext
    {
        public FreeItemContext(DbContextOptions<FreeItemContext> options) : base(options)
        {
            
        }

        public DbSet<FreeItem> FreeItems { get; set; }
    }
}