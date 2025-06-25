using CrudApi.NewFolder.Models; // Change this if your namespace differs
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
