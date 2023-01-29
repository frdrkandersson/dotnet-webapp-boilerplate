using Microsoft.AspNetCore.SignalR;

namespace Boilerplate.Infrastructure.Notifications;

public class NotificationHub : Hub
{
  // TODO : hub with tenant support

  //private readonly ITenantInfo _currentTenant;

  //public NotificationHub(ITenantInfo currentTenant)
  //{
  //  _currentTenant = currentTenant;
  //}

  //public override async Task OnConnectedAsync()
  //{
  //  if (_currentTenant is null)
  //  {
  //    throw new UnauthorizedException("Authentication Failed.");
  //  }

  //  await Groups.AddToGroupAsync(Context.ConnectionId, $"GroupTenant-{_currentTenant.Id}");

  //  await base.OnConnectedAsync();

  //  _logger.LogInformation("A client connected to NotificationHub: {connectionId}", Context.ConnectionId);
  //}

  //public override async Task OnDisconnectedAsync(Exception? exception)
  //{
  //  await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"GroupTenant-{_currentTenant!.Id}");

  //  await base.OnDisconnectedAsync(exception);

  //  _logger.LogInformation("A client disconnected from NotificationHub: {connectionId}", Context.ConnectionId);
  //}
}
