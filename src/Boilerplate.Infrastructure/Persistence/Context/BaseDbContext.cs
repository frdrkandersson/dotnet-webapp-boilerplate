using Boilerplate.Application.Core.Events;
using Boilerplate.Application.Core.Notifications;
using Boilerplate.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Persistence.Context;

public abstract class BaseDbContext : DbContext
{
  private readonly IEventPublisher _eventPublisher;
  private readonly INotificationPublisher _notificationPublisher;

  public BaseDbContext(DbContextOptions options, IEventPublisher eventPublisher, INotificationPublisher notificationPublisher)
    : base(options)
  {
    _eventPublisher = eventPublisher;
    _notificationPublisher = notificationPublisher;
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    await SendDomainEventsAsync();

    return await base.SaveChangesAsync(cancellationToken);
  }

  private async Task SendDomainEventsAsync()
  {
    var entitiesWithEvents = ChangeTracker.Entries<IEntity>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Count > 0)
        .ToArray();

    foreach (var entity in entitiesWithEvents)
    {
      var domainEvents = entity.DomainEvents.ToArray();
      entity.DomainEvents.Clear();
      foreach (var domainEvent in domainEvents)
      {
        await _eventPublisher.PublishAsync(domainEvent);
        await _notificationPublisher.SendToAllAsync(domainEvent);
      }
    }
  }
}
