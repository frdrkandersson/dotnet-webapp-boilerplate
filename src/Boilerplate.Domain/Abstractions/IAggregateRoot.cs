namespace Boilerplate.Domain.Abstractions;

// This is a marker interface
// Used to be able to have a repository over the entity
public interface IAggregateRoot : IAggregateRoot<Guid>
{
}

public interface IAggregateRoot<TId> : IEntity<TId>
{
}