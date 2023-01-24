namespace Boilerplate.Domain.Abstractions;

public abstract class DomainEvent : IEvent
{
  public Guid Id { get; } = Guid.NewGuid();
}
