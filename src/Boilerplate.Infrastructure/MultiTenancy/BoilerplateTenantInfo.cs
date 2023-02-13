using Finbuckle.MultiTenant;

namespace Boilerplate.Infrastructure.MultiTenancy;

public class BoilerplateTenantInfo : ITenantInfo
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public string Name { get; set; } = string.Empty;
  public string Identifier { get; set; } = string.Empty;
  public string? ConnectionString { get; set; }

  string? ITenantInfo.Id { get => Id; set => Id = value ?? throw new InvalidOperationException("Id can't be null."); }
  string? ITenantInfo.Identifier { get => Identifier; set => Identifier = value ?? throw new InvalidOperationException("Identifier can't be null."); }
  string? ITenantInfo.Name { get => Name; set => Name = value ?? throw new InvalidOperationException("Name can't be null."); }
  string? ITenantInfo.ConnectionString { get => ConnectionString; set => ConnectionString = value; }

}
