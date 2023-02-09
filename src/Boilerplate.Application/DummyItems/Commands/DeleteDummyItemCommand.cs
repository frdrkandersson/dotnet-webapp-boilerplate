using Boilerplate.Application.Core.Exceptions;
using Boilerplate.Application.Core.Persistence;
using Boilerplate.Domain.Entities;
using MediatR;

namespace Boilerplate.Application.DummyItems.Commands;

public record DeleteDummyItemCommand(Guid Id) : IRequest;

internal class DeleteDummyItemCommandHandler : AsyncRequestHandler<DeleteDummyItemCommand>
{
  public readonly IRepositoryWithEvents<DummyItem> _repository;

  public DeleteDummyItemCommandHandler(IRepositoryWithEvents<DummyItem> repository)
  {
    _repository = repository;
  }

  protected async override Task Handle(DeleteDummyItemCommand request, CancellationToken cancellationToken)
  {
    var item = await _repository.GetByIdAsync(request.Id, cancellationToken)
      ?? throw new NotFoundException($"DummyItem {request.Id} Not Found.");

    await _repository.DeleteAsync(item, cancellationToken);
  }
}