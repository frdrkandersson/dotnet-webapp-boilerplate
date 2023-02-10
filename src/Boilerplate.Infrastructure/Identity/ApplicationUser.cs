using Microsoft.AspNetCore.Identity;

namespace Boilerplate.Infrastructure.Identity;

internal class ApplicationUser : IdentityUser<Guid>
{
  public string? FirstName { get; init; }
  public string? LastName { get; init; }
}
