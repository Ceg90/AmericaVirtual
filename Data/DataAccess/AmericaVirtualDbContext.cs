using Api.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.DataAccess
{
    public class AmericaVirtualDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public AmericaVirtualDbContext(DbContextOptions<AmericaVirtualDbContext> options)
            : base(options)
        {
        }
    }
}
