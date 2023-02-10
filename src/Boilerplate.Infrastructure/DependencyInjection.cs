using Boilerplate.Application.Core.Events;
using Boilerplate.Application.Core.Notifications;
using Boilerplate.Infrastructure.Events;
using Boilerplate.Infrastructure.Identity;
using Boilerplate.Infrastructure.Notifications;
using Boilerplate.Infrastructure.Persistence;
using Boilerplate.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Boilerplate.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
  {
    services.AddIdentityServer(config);
    services.AddPersistence(config);
    services.AddMediatR(Assembly.GetExecutingAssembly());
    services.AddSignalR();
    services.AddScoped<IEventPublisher, MediatorEventPublisher>();
    services.AddScoped<INotificationPublisher, SignalRNotificationPublisher>();
    return services;
  }

  public static void RunMigrations(this WebApplication app)
  {
    using IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    using var applicationDb = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    applicationDb.Database.Migrate();

    using var identityDb = serviceScope.ServiceProvider.GetRequiredService<Boilerplate.Infrastructure.Identity.IdentityDbContext>();
    identityDb.Database.Migrate();
  }
}
