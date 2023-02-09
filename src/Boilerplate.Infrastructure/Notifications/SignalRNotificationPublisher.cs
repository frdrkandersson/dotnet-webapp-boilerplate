using Boilerplate.Application.Core.Notifications;
using Boilerplate.Domain.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Boilerplate.Infrastructure.Notifications;

internal class SignalRNotificationPublisher : INotificationPublisher
{
  private readonly IHubContext<NotificationHub> _notificationHub;
  //private readonly ITenantInfo _currentTenant;

  // TODO: Add tenant

  public SignalRNotificationPublisher(IHubContext<NotificationHub> notificationHub)
  {
    _notificationHub = notificationHub;
  }

  public Task SendToAllAsync(IEvent domainEvent, CancellationToken cancellationToken = default)
    => _notificationHub.Clients.All.SendAsync("DomainEvent", domainEvent.GetType().FullName, domainEvent, cancellationToken);

  //public Task SendToAllAsync(INotification notification, CancellationToken cancellationToken)
  //  => _notificationHubContext.Clients.Group($"Tenant-{Tenant.Id}").SendAsync("", notification.GetType().FullName, notification, cancellationToken);
}
