namespace Boilerplate.Domain.Abstractions;

public interface ISoftDelete
{
  Guid? DeletedById { get; set; }
  DateTimeOffset? Deleted { get; set; }
}
