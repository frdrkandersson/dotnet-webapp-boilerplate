using Boilerplate.Application.Core.Exceptions;
using Boilerplate.Application.Core.Persistence;
using Boilerplate.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Boilerplate.Application.DummyItems.Commands;

public record UpdateDummyItemCommand(Guid Id, int IntProp, string StringProp) : IRequest<DummyItemDto>;

internal class UpdateDummyItemCommandValidator : AbstractValidator<UpdateDummyItemCommand>
{
  public UpdateDummyItemCommandValidator()
  {
    RuleFor(x => x.Id).NotEmpty();
    RuleFor(x => x.IntProp).NotEmpty();
    RuleFor(x => x.StringProp).NotEmpty().MaximumLength(150);
  }
}

internal class UpdateDummyItemCommandHandler : IRequestHandler<UpdateDummyItemCommand, DummyItemDto>
{
  public readonly IRepositoryWithEvents<DummyItem> _repository;

  public UpdateDummyItemCommandHandler(IRepositoryWithEvents<DummyItem> repository)
  {
    _repository = repository;
  }

  public async Task<DummyItemDto> Handle(UpdateDummyItemCommand request, CancellationToken cancellationToken)
  {
    var item = await _repository.GetByIdAsync(request.Id, cancellationToken)
      ?? throw new NotFoundException($"DummyItem {request.Id} Not Found.");

    item.IntProp = request.IntProp;
    item.StringProp = request.StringProp;

    await _repository.UpdateAsync(item, cancellationToken);

    return new DummyItemDto(item.Id, item.IntProp, item.StringProp);
  }
}
