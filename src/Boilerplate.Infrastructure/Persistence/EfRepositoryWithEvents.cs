using Ardalis.Specification.EntityFrameworkCore;
using Boilerplate.Application.Core.Persistence;
using Boilerplate.Domain.Abstractions;
using Boilerplate.Domain.Events;

namespace Boilerplate.Infrastructure.Persistence;

public class EfRepositoryWithEvents<T> : RepositoryBase<T>, IRepositoryWithEvents<T>
    where T : class, IAggregateRoot
{
  public EfRepositoryWithEvents(ApplicationDbContext dbContext) : base(dbContext) { }

  public override Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
  {
    entity.DomainEvents.Add(new EntityCreatedEvent<T>(entity));
    return base.AddAsync(entity, cancellationToken);
  }

  public override Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
  {
    foreach (var entity in entities)
    {
      entity.DomainEvents.Add(new EntityCreatedEvent<T>(entity));
    }

    return base.AddRangeAsync(entities, cancellationToken);
  }

  public override Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
  {
    entity.DomainEvents.Add(new EntityDeletedEvent<T>(entity));
    return base.DeleteAsync(entity, cancellationToken);
  }

  public override Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
  {
    foreach (var entity in entities)
    {
      entity.DomainEvents.Add(new EntityCreatedEvent<T>(entity));
    }

    return base.DeleteRangeAsync(entities, cancellationToken);
  }

  public override Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
  {
    entity.DomainEvents.Add(new EntityUpdatedEvent<T>(entity));
    return base.UpdateAsync(entity, cancellationToken);
  }

  public override Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
  {
    foreach (var entity in entities)
    {
      entity.DomainEvents.Add(new EntityCreatedEvent<T>(entity));
    }

    return base.UpdateRangeAsync(entities, cancellationToken);
  }
}