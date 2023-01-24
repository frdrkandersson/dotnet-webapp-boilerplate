using Boilerplate.Application.Core.Events;
using Boilerplate.Domain.Abstractions;
using MediatR;

namespace Boilerplate.Infrastructure.Events;

internal class MediatorEventPublisher : IEventPublisher
{
  private readonly IPublisher _mediator;

  public MediatorEventPublisher(IPublisher mediator)
  {

    _mediator = mediator;
  }

  public Task PublishAsync(IEvent @event) => _mediator.Publish(CreateEventNotification(@event));

  private INotification CreateEventNotification(IEvent @event) =>
    (INotification)Activator.CreateInstance(
        typeof(EventNotification<>).MakeGenericType(@event.GetType()), @event)!;
}
