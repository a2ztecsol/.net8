using DotNetMVCEF.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace DotNetMVCEF.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
