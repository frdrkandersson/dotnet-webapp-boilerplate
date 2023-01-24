using Boilerplate.Domain.Abstractions;
using MediatR;

namespace Boilerplate.Application.Core.Events;

internal abstract class EventNotificationHandler<TEvent> : INotificationHandler<EventNotification<TEvent>>
    where TEvent : IEvent
{
  public Task Handle(EventNotification<TEvent> notification, CancellationToken cancellationToken)
    => Handle(notification.Event, cancellationToken);

  public abstract Task Handle(TEvent @event, CancellationToken cancellationToken);
}
