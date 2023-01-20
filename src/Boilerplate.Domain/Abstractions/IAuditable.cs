namespace Boilerplate.Domain.Abstractions;

public interface IAuditable
{
  Guid CreatedById { get; set; }
  DateTimeOffset Created { get; set; }
  Guid? LastModifiedById { get; set; }
  DateTimeOffset? LastModified { get; set; }
}
