using Boilerplate.Domain.Abstractions;

namespace Boilerplate.Domain.Events;

public class EntityCreatedEvent<TEntity> : DomainEvent
  where TEntity : IEntity
{
  public EntityCreatedEvent(TEntity entity) => Entity = entity;

  public TEntity Entity { get; }
}