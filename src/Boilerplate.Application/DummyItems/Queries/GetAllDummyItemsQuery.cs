using Boilerplate.Application.Core.Persistence;
using Boilerplate.Domain.Entities;
using MediatR;

namespace Boilerplate.Application.DummyItems.Queries;

public record GetAllDummyItemsQuery : IRequest<List<DummyItemDto>>;

internal class GetAllDummyItemsQueryHandler : IRequestHandler<GetAllDummyItemsQuery, List<DummyItemDto>>
{
  public readonly IRepository<DummyItem> _repository;

  public GetAllDummyItemsQueryHandler(IRepository<DummyItem> repository)
  {
    _repository = repository;
  }

  public async Task<List<DummyItemDto>> Handle(GetAllDummyItemsQuery request, CancellationToken cancellationToken)
  {
    var items = await _repository.ListAsync(cancellationToken);
    return items.Select(x => new DummyItemDto(x.Id, x.IntProp, x.StringProp)).ToList();
  }
}
