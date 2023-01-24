using Boilerplate.Application.Core.Events;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Boilerplate.Application.DummyItems.EventHandlers;

internal class DummyItemCreatedEvent : EventNotificationHandler<EntityCreatedEvent<DummyItem>>
{
  private readonly ILogger<DummyItemCreatedEvent> _logger;

  public DummyItemCreatedEvent(ILogger<DummyItemCreatedEvent> logger) => _logger = logger;

  public override Task Handle(EntityCreatedEvent<DummyItem> @event, CancellationToken cancellationToken)
  {
    _logger.LogInformation("New DummyItem created with Id: {Id}", @event.Entity.Id);
    return Task.CompletedTask;
  }
}
