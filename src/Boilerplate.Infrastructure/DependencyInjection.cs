using Boilerplate.Application.Core.Events;
using Boilerplate.Infrastructure.Events;
using Boilerplate.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

    services.AddMediatR(Assembly.GetExecutingAssembly());

    services.AddScoped<IEventPublisher, MediatorEventPublisher>();

    services.AddRepositories();

    return services;
  }
}
