using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Persistence;

public sealed class ApplicationDbContext : BaseDbContext
{
  public ApplicationDbContext(DbContextOptions options)
    : base(options)
  {
  }

  public DbSet<DummyItem> Items => Set<DummyItem>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }
}
