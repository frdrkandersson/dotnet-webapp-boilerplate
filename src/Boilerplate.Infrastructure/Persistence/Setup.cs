using Boilerplate.Application.Core.Persistence;
using Boilerplate.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Infrastructure.Persistence;
internal static class Setup
{
  public static IServiceCollection AddRepositories(this IServiceCollection services)
  {
    var domainAssembly = typeof(Domain.AssemblyReference).Assembly;
    var aggregateRootTypes = domainAssembly.GetExportedTypes()
                .Where(t => typeof(IAggregateRoot).IsAssignableFrom(t) && t.IsClass)
                .ToList();

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IRepositoryWithEvents<>), typeof(EfRepositoryWithEvents<>));

    foreach (var type in aggregateRootTypes)
    {
      services.AddScoped(typeof(IReadRepository<>).MakeGenericType(type),
        sp => sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(type)));
    }

    return services;
  }
}