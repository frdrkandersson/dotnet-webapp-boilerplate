using Boilerplate.Application.Core.Events;
using Boilerplate.Domain.Abstractions;
using MediatR;

namespace Boilerplate.Application.Core.Notifications;

internal abstract class NotificationHandler<TEvent> : INotificationHandler<DomainEventWrapper<TEvent>>
    where TEvent : IEvent
{
  private readonly INotificationPublisher _notificationPublisher;

  protected NotificationHandler(INotificationPublisher notificationPublisher)
  {
    _notificationPublisher = notificationPublisher;
  }

  public Task Handle(DomainEventWrapper<TEvent> domainEvent, CancellationToken cancellationToken)
  {
    INotification notification = ((dynamic)domainEvent).Event;
    return _notificationPublisher.SendToAllAsync(notification, cancellationToken);
  }
}