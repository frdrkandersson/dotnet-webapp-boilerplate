using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var builder = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", true, true)
    .AddJsonFile($"appsettings.{environmentName}.json", true, true)
    .AddEnvironmentVariables();
var configuration = builder.Build();

var url = configuration["HubUrl"] ?? "";

await using var connection = new HubConnectionBuilder()
.WithUrl(url)
.Build();

connection.On<object, object>("DomainEvent", (type, data) =>
{
  Console.WriteLine($"Type: {type}");
  Console.WriteLine($"Data: {JsonSerializer.Serialize(data)}");
});

await connection.StartAsync();

await Host.CreateDefaultBuilder(args)
    .RunConsoleAsync();