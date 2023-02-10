using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Infrastructure.Identity;

internal static class Setup
{
  public static IServiceCollection AddIdentityServer(this IServiceCollection services, IConfiguration config)
  {
    string connectionString = config.GetConnectionString("BoilerplateDb")!;

    services.AddDbContext<IdentityDbContext>(options
      => options.UseNpgsql(connectionString));

    services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
    {
      options.Password.RequiredLength = 6;
      options.Password.RequireDigit = false;
      options.Password.RequireNonAlphanumeric = false;
      options.Password.RequireUppercase = false;
    })
      .AddEntityFrameworkStores<IdentityDbContext>()
      .AddDefaultTokenProviders();

    //var identityServerBuilder = services.AddIdentityServer(options =>
    //{
    //  options.Events.RaiseErrorEvents = true;
    //  options.Events.RaiseInformationEvents = true;
    //  options.Events.RaiseFailureEvents = true;
    //  options.Events.RaiseSuccessEvents = true;
    //})
    //  .AddInMemoryIdentityResources(InMemoryConfiguration.IdentityResources)
    //  .AddInMemoryApiResources(InMemoryConfiguration.ApiResources)
    //  .AddInMemoryApiScopes(InMemoryConfiguration.ApiScopes)
    //  .AddInMemoryClients(InMemoryConfiguration.Clients)
    //  .AddAspNetIdentity<ApplicationUser>()
    //  .AddResourceOwnerValidator<UserValidator>();

    //if (env.IsDevelopment())
    //{
    //  identityServerBuilder.AddDeveloperSigningCredential();
    //}

    return services;
  }
}
