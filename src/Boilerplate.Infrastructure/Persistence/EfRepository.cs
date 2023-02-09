using Ardalis.Specification.EntityFrameworkCore;
using Boilerplate.Application.Core.Persistence;
using Boilerplate.Domain.Abstractions;

namespace Boilerplate.Infrastructure.Persistence;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
  where T : class, IAggregateRoot
{
  public EfRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}