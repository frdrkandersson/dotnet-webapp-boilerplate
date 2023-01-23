using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebApi.Controllers.Abstractions;

[Route("api/v{version:apiVersion}/[controller]")]
public abstract class VersionedApiController : BaseController
{
}
