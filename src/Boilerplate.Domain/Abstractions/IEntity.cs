namespace Boilerplate.Domain.Abstractions;

public interface IEntity
{
  List<DomainEvent> DomainEvents { get; }
}

public interface IEntity<TId> : IEntity, IEquatable<IEntity<TId>>
{
  TId Id { get; }
}