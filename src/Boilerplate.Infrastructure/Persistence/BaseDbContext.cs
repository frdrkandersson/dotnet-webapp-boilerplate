using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Persistence;

public abstract class BaseDbContext : DbContext
{
  public BaseDbContext(DbContextOptions options)
    : base(options)
  {
  }
}
