using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Infrastructure.MultiTenancy;

internal static class Setup
{
  public static IServiceCollection AddMultitenancy(this IServiceCollection services, IConfiguration config)
  {
    ArgumentNullException.ThrowIfNull(services);

    string connectionString = config.GetConnectionString("BoilerplateDb")!;

    services.AddDbContext<TenantDbContext>(options
      => options.UseNpgsql(connectionString));

    services.AddMultiTenant<BoilerplateTenantInfo>()
      .WithClaimStrategy("Tenant")
      .WithEFCoreStore<TenantDbContext, BoilerplateTenantInfo>();

    return services;
  }
}
