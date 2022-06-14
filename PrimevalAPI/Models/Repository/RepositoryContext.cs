using Microsoft.EntityFrameworkCore;

namespace PrimevalAPI.Models.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Repository> _repositorySet { get; set; }
    }
}
