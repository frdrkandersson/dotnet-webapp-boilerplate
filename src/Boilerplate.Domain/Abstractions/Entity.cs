using System.ComponentModel.DataAnnotations.Schema;

namespace Boilerplate.Domain.Abstractions;

public abstract class Entity : Entity<Guid>
{
  protected Entity() : base(Guid.NewGuid())
  {
  }
}

public abstract class Entity<TId> : IEntity<TId>
    where TId : notnull
{
  protected Entity(TId id) { Id = id; }

  public TId Id { get; protected set; }

  [NotMapped]
  public List<DomainEvent> DomainEvents { get; } = new();

  public override bool Equals(object? obj) => obj is Entity<TId> entity && Id.Equals(entity.Id);

  public static bool operator ==(Entity<TId> l, Entity<TId> r) => Equals(l, r);

  public static bool operator !=(Entity<TId> l, Entity<TId> r) => !Equals(l, r);

  public override int GetHashCode() => Id.GetHashCode() * 11;

  bool IEquatable<IEntity<TId>>.Equals(IEntity<TId>? other) => Equals(other);
}