using Boilerplate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    string connectionString = configuration.GetConnectionString("BoilerplateDb")!;

    services.AddDbContext<ApplicationDbContext>((sp, options) =>
    {
      options.UseNpgsql(connectionString);
    });

    services.AddRepositories();

    return services;
  }
}
