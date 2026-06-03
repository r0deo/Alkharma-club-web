using AlKarmahClub.Api.Common;
using AlKarmahClub.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlKarmahClub.Api.Controllers;

public sealed class SystemController : BaseApiController
{
    [HttpGet("status")]
    [ProducesResponseType(typeof(ApiResponse<SystemStatusResponse>), StatusCodes.Status200OK)]
    public ActionResult<ApiResponse<SystemStatusResponse>> GetStatus()
    {
        var status = new SystemStatusResponse("AlKarmahClub.Api", "Healthy");

        return Ok(ApiResponse<SystemStatusResponse>.Ok(status, "AlKarmahClub API is running"));
    }
}
