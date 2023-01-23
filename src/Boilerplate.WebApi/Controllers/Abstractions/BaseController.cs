﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebApi.Controllers.Abstractions;

[ApiController]
public abstract class BaseController : ControllerBase
{
  private ISender _mediator = null!;

  protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
