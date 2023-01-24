using Boilerplate.Application.DummyItems.Commands;
using Boilerplate.Application.DummyItems.Queries;
using Boilerplate.Domain.Entities;
using Boilerplate.WebApi.Controllers.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebApi.Controllers;

//[Authorize]
public class DummyItemController : VersionedApiController
{
  [HttpGet]
  public async Task<ActionResult<IList<DummyItem>>> GetAllAsync() => await Mediator.Send(new GetAllDummyItemsQuery());

  [HttpPost]
  public async Task<ActionResult<Guid>> CreateAsync(CreateDummyItemCommand request) => await Mediator.Send(request);
}
