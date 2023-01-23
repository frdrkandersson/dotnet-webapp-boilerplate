using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebApi.Controllers.Abstractions;

[Route("api/[controller]")]
public abstract class VersionNeutralController : BaseController
{
}
