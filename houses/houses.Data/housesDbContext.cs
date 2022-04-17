using houses.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace houses.Data
{
    public class housesDbContext : DbContext
    {
        public housesDbContext(DbContextOptions<housesDbContext> options)
            : base(options) { }

        public DbSet<Houses> Houses { get; set; }
    }
}
