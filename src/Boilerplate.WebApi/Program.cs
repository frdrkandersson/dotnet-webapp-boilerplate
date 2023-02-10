using Boilerplate.Application;
using Boilerplate.Infrastructure;
using Boilerplate.Infrastructure.Notifications;
using Boilerplate.WebApi.Middleware;

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

app.RunMigrations();

app.Run();
