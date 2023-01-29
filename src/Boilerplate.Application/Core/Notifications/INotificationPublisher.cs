namespace Boilerplate.Application.Core.Notifications;

public interface INotificationPublisher
{
  Task SendToAllAsync(INotification notification, CancellationToken cancellationToken);
}
