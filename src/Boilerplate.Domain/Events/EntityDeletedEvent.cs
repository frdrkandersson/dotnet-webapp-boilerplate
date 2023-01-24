using Boilerplate.Domain.Abstractions;

namespace Boilerplate.Domain.Events;

public class EntityDeletedEvent<TEntity> : DomainEvent
  where TEntity : IEntity
{
  public EntityDeletedEvent(TEntity entity) => Entity = entity;

  public TEntity Entity { get; }
}