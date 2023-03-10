using Boilerplate.Application.Core.Events;
using Boilerplate.Application.Core.Notifications;
using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Persistence.Context;

public sealed class ApplicationDbContext : BaseDbContext
{
  public ApplicationDbContext(DbContextOptions options, IEventPublisher eventPublisher, INotificationPublisher notificationPublisher)
    : base(options, eventPublisher, notificationPublisher)
  {
  }

  public DbSet<DummyItem> Items => Set<DummyItem>();
}
