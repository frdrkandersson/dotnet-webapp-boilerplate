using Boilerplate.Application.Core.Notifications;
using Microsoft.AspNetCore.SignalR;

namespace Boilerplate.Infrastructure.Notifications;

internal class SignalRNotificationPublisher : INotificationPublisher
{
  private readonly IHubContext<NotificationHub> _notificationHubContext;
  //private readonly ITenantInfo _currentTenant;

  // TODO: Add tenant

  public SignalRNotificationPublisher(IHubContext<NotificationHub> notificationHubContext)
  {
    _notificationHubContext = notificationHubContext;
  }

  public Task SendToAllAsync(INotification notification, CancellationToken cancellationToken)
    => _notificationHubContext.Clients.All.SendAsync("", notification.GetType().FullName, notification, cancellationToken);

  //public Task SendToAllAsync(INotification notification, CancellationToken cancellationToken)
  //  => _notificationHubContext.Clients.Group($"Tenant-{Tenant.Id}").SendAsync("", notification.GetType().FullName, notification, cancellationToken);
}
