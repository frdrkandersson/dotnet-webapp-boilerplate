namespace Boilerplate.Domain.Abstractions;

public abstract class AuditableEntity : AuditableEntity<Guid>
{
  protected AuditableEntity() : base(Guid.NewGuid()) { }
}

public abstract class AuditableEntity<TId> : Entity<TId>, IAuditable, ISoftDelete
  where TId : notnull
{
  protected AuditableEntity(TId id)
    : base(id)
    => Created = DateTimeOffset.UtcNow;

  public Guid CreatedById { get; set; } = Guid.Empty;
  public DateTimeOffset Created { get; set; }
  public Guid? LastModifiedById { get; set; }
  public DateTimeOffset? LastModified { get; set; }
  public Guid? DeletedById { get; set; }
  public DateTimeOffset? Deleted { get; set; }
}
