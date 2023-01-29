using Boilerplate.Domain.Abstractions;

namespace Boilerplate.Application.Core.Events;

public class DomainEventWrapper<TEvent> : MediatR.INotification
  where TEvent : IEvent
{
  public DomainEventWrapper(TEvent @event) => Event = @event;

  public TEvent Event { get; }
}
