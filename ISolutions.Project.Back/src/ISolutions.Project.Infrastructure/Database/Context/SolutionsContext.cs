using ISolutions.Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISolutions.Project.Infrastructure.Database.Context;
public class SolutionsContext : DbContext
{
    public DbSet<UserEntitiy> Users { get; set; }

    public SolutionsContext(DbContextOptions<SolutionsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SolutionsContext).Assembly);
    }
}
