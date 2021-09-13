using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AwardsDBContext : DbContext
    {
        public AwardsDBContext(DbContextOptions<AwardsDBContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
