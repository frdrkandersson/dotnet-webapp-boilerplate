
## Application Migrations
dotnet ef migrations add {{Migration Name}} -p src/Boilerplate.Infrastructure -c Boilerplate.Infrastructure.Persistence.Context.ApplicationDbContext -o Persistence/Migrations --startup-project src/Boilerplate.WebApi

## Identity Migrations
dotnet ef migrations add {{Migration Name}} -p src/Boilerplate.Infrastructure -c Boilerplate.Infrastructure.Identity.IdentityDbContext -o Identity/Migrations --startup-project src/Boilerplate.WebApi

## Tenant Migrations
dotnet ef migrations add {{Migration Name}} -p src/Boilerplate.Infrastructure -c Boilerplate.Infrastructure.MultiTenancy.TenantDbContext -o MultiTenancy/Migrations --startup-project src/Boilerplate.WebApi