using Boilerplate.Domain.Abstractions;

namespace Boilerplate.Domain.Events;

public class EntityUpdatedEvent<TEntity> : DomainEvent
  where TEntity : IEntity
{
  public EntityUpdatedEvent(TEntity entity) => Entity = entity;

  public TEntity Entity { get; }
}