
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Identity;

internal class IdentityDbContext : IdentityDbContext<ApplicationUser,
  IdentityRole<Guid>,
  Guid,
  IdentityUserClaim<Guid>,
  IdentityUserRole<Guid>,
  IdentityUserLogin<Guid>,
  IdentityRoleClaim<Guid>,
  IdentityUserToken<Guid>>
{
  public IdentityDbContext(DbContextOptions<IdentityDbContext> options, IHttpContextAccessor httpContextAccessor)
    : base(options)
    => ArgumentNullException.ThrowIfNull(httpContextAccessor);
}
