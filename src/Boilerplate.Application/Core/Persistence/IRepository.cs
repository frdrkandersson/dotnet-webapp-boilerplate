using Ardalis.Specification;
using Boilerplate.Domain.Abstractions;

namespace Boilerplate.Application.Core.Persistence;

public interface IReadRepository<T> : IReadRepository<T, Guid>
  where T : class, IAggregateRoot<Guid>
{
}

public interface IReadRepository<T, TId> : IReadRepositoryBase<T>
  where T : class, IAggregateRoot<TId>
  where TId : notnull
{
}

public interface IRepository<T> : IRepository<T, Guid>
  where T : class, IAggregateRoot<Guid>
{
}

public interface IRepository<T, TId> : IRepositoryBase<T>
  where T : class, IAggregateRoot<TId>
  where TId : notnull
{
}

public interface IRepositoryWithEvents<T> : IRepositoryWithEvents<T, Guid>
  where T : class, IAggregateRoot<Guid>
{
}

public interface IRepositoryWithEvents<T, TId> : IRepositoryBase<T>
  where T : class, IAggregateRoot<TId>
  where TId : notnull
{
}