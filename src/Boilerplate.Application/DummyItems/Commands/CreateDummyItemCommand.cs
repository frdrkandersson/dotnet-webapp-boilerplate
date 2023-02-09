using Boilerplate.Application.Core.Persistence;
using Boilerplate.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Boilerplate.Application.DummyItems.Commands;

public record CreateDummyItemCommand(int IntProp, string StringProp) : IRequest<DummyItemDto>;

internal class CreateDummyItemCommandValidator : AbstractValidator<CreateDummyItemCommand>
{
  public CreateDummyItemCommandValidator()
  {
    RuleFor(x => x.IntProp).NotEmpty();
    RuleFor(x => x.StringProp).NotEmpty().MaximumLength(150);
  }
}

internal class CreateDummyItemCommandHandler : IRequestHandler<CreateDummyItemCommand, DummyItemDto>
{
  public readonly IRepositoryWithEvents<DummyItem> _repository;

  public CreateDummyItemCommandHandler(IRepositoryWithEvents<DummyItem> repository)
  {
    _repository = repository;
  }

  public async Task<DummyItemDto> Handle(CreateDummyItemCommand request, CancellationToken cancellationToken)
  {
    var item = new DummyItem()
    {
      IntProp = request.IntProp,
      StringProp = request.StringProp
    };

    var newItem = await _repository.AddAsync(item, cancellationToken);

    return new DummyItemDto(newItem.Id, newItem.IntProp, newItem.StringProp);
  }
}
