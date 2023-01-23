using Boilerplate.Application.Core.Persistence;
using Boilerplate.Domain.Entities;
using MediatR;

namespace Boilerplate.Application.DummyItems.Queries;

public record GetAllDummyItemsQuery : IRequest<List<DummyItem>>;

internal class GetAllDummyItemsQueryHandler : IRequestHandler<GetAllDummyItemsQuery, List<DummyItem>>
{
  public readonly IRepository<DummyItem> _repository;

  public GetAllDummyItemsQueryHandler(IRepository<DummyItem> repository)
  {
    _repository = repository;
  }

  public Task<List<DummyItem>> Handle(GetAllDummyItemsQuery request, CancellationToken cancellationToken)
    => _repository.ListAsync(cancellationToken);
}
