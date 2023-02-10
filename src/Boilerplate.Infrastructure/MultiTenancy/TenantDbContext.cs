using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.MultiTenancy;

internal class TenantDbContext : EFCoreStoreDbContext<BoilerplateTenantInfo>
{
  public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<BoilerplateTenantInfo>().ToTable("Tenants");

    base.OnModelCreating(modelBuilder);
  }
}
