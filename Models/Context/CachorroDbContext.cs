using Microsoft.EntityFrameworkCore;

namespace apiCachorro.Models.Context
{
    public class CachorroDbContext : DbContext
    {
        public DbSet<Cachorro> Cachorro { get; set; }
        public CachorroDbContext(
            DbContextOptions<CachorroDbContext> options
            ) : base(options)
        { }

    }
}