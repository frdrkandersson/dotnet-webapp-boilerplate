using System.ComponentModel.DataAnnotations.Schema;

namespace Boilerplate.Domain.Abstractions;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
  protected AggregateRoot(TId id) : base(id)
  {
  }

  [NotMapped]
  public List<DomainEvent> DomainEvents => new();
}