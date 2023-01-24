using Boilerplate.Application.Core.Persistence;
using Boilerplate.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Boilerplate.Application.DummyItems.Commands;

public record CreateDummyItemCommand(int IntProp, string StringProp) : IRequest<Guid>;

internal class CreateDummyItemCommandValidator : AbstractValidator<CreateDummyItemCommand>
{
  public CreateDummyItemCommandValidator()
  {
    RuleFor(x => x.IntProp).NotEmpty();
    RuleFor(x => x.StringProp).NotEmpty().MaximumLength(150);
  }
}

internal class CreateDummyItemCommandHandler : IRequestHandler<CreateDummyItemCommand, Guid>
{
  public readonly IRepositoryWithEvents<DummyItem> _repository;

  public CreateDummyItemCommandHandler(IRepositoryWithEvents<DummyItem> repository)
  {
    _repository = repository;
  }

  public async Task<Guid> Handle(CreateDummyItemCommand request, CancellationToken cancellationToken)
  {
    var item = new DummyItem()
    {
      IntProp = request.IntProp,
      StringProp = request.StringProp
    };

    await _repository.AddAsync(item, cancellationToken);

    return item.Id;
  }
}
