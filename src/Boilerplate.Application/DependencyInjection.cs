using Boilerplate.Application.Core.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Boilerplate.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services
      .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
      .AddMediatR(Assembly.GetExecutingAssembly());

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    return services;
  }
}
