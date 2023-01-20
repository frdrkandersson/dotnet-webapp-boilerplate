namespace Boilerplate.Domain.Abstractions;

public abstract class DomainEvent
{
    public Guid Id { get; } = Guid.NewGuid();
}
