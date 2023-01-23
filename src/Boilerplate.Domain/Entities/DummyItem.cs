using Boilerplate.Domain.Abstractions;

namespace Boilerplate.Domain.Entities;

public sealed class DummyItem : AuditableEntity, IAggregateRoot
{
  public required int IntProp { get; set; }
  public required string StringProp { get; set; }
}
