using AlKarmahClub.Api.Controllers;
using AlKarmahClub.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AlKarmahClub.Api.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : BaseApiController
{
    [HttpGet("throw-not-found")]
    public IActionResult ThrowNotFound()
    {
        throw new NotFoundException("Test entity", "test-key");
    }

    [HttpGet("throw-validation")]
    public IActionResult ThrowValidation()
    {
        throw new ValidationException("Invalid input value");
    }

    [HttpGet("throw-unhandled")]
    public IActionResult ThrowUnhandled()
    {
        throw new InvalidOperationException("Test unhandled exception");
    }
}