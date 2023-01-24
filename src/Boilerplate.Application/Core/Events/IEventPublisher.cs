using Boilerplate.Domain.Abstractions;

namespace Boilerplate.Application.Core.Events;

public interface IEventPublisher
{
  Task PublishAsync(IEvent @event);
}
