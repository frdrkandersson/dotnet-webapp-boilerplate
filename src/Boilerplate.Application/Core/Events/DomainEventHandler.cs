using Boilerplate.Domain.Abstractions;
using MediatR;

namespace Boilerplate.Application.Core.Events;

internal abstract class DomainEventHandler<TEvent> : INotificationHandler<DomainEventWrapper<TEvent>>
    where TEvent : IEvent
{
  public Task Handle(DomainEventWrapper<TEvent> domainEvent, CancellationToken cancellationToken)
    => Handle(domainEvent.Event, cancellationToken);

  public abstract Task Handle(TEvent @event, CancellationToken cancellationToken);
}
