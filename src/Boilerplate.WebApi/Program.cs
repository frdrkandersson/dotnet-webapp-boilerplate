using Boilerplate.Application;
using Boilerplate.Infrastructure;
using Boilerplate.Infrastructure.Notifications;
using Boilerplate.Infrastructure.Persistence;
using Boilerplate.WebApi.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddApiVersioning(config =>
{
  config.AssumeDefaultVersionWhenUnspecified = true;
  config.ReportApiVersions = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
  .AddApplication()
  .AddInfrastructure(config);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.MapHub<NotificationHub>("/notifications");

using IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
using ApplicationDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
dbContext.Database.Migrate();

app.Run();
