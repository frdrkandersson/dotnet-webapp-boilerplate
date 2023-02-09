using Boilerplate.Application.DummyItems;
using Boilerplate.Application.DummyItems.Commands;
using Boilerplate.Application.DummyItems.Queries;
using Boilerplate.WebApi.Controllers.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebApi.Controllers;

//[Authorize]
public class DummyItemsController : VersionedApiController
{
  [HttpGet]
  public async Task<ActionResult<IList<DummyItemDto>>> GetAllAsync() => await Mediator.Send(new GetAllDummyItemsQuery());

  [HttpPost]
  public async Task<ActionResult<DummyItemDto>> CreateAsync(DummyItemDto dto)
    => await Mediator.Send(new CreateDummyItemCommand(dto.IntProp, dto.StringProp));

  [HttpPut("{id}")]
  public async Task<ActionResult<DummyItemDto>> UpdateAsync(Guid id, [FromBody] DummyItemDto dto)
    => await Mediator.Send(new UpdateDummyItemCommand(id, dto.IntProp, dto.StringProp));

  [HttpDelete("{id}")]
  public async Task<ActionResult> DelteAsync(Guid id)
  {
    await Mediator.Send(new DeleteDummyItemCommand(id));
    return Ok();
  }
}
