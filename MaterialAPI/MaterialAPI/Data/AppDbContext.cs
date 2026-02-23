using MaterialAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MaterialAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Material> Material { get; set; }
    }
}
