using Boilerplate.Application.Core.Events;
using Boilerplate.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Persistence;

public abstract class BaseDbContext : DbContext
{
  private readonly IEventPublisher _eventPublisher;

  public BaseDbContext(DbContextOptions options, IEventPublisher eventPublisher)
    : base(options)
  {
    _eventPublisher = eventPublisher;
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    await SendDomainEventsAsync();

    int result = await base.SaveChangesAsync(cancellationToken);

    return result;
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
      }
    }
  }
}
