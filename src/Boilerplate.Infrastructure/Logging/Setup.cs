using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Boilerplate.Infrastructure.Logging;

public static class Setup
{
  public static WebApplicationBuilder AddSerilogLogging(this WebApplicationBuilder builder)
  {
    var logger = new LoggerConfiguration()
      .ReadFrom.Configuration(builder.Configuration)
      .MinimumLevel.Override("System", LogEventLevel.Warning)
      .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
      .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
      .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Error)
      .Enrich.FromLogContext()
      .CreateLogger();

    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(logger);

    return builder;
  }
}
