namespace Boilerplate.Application.Core.Notifications;

public interface INotificationPublisher
{
  Task SendToAllAsync(Domain.Abstractions.IEvent notification, CancellationToken cancellationToken = default);
}
