using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Common.Contracts;

namespace Mfa.Modules.Due;

[ApiController]
[Route("api/dues")]
[Authorize]

public class DueController: ControllerBase {
    private readonly IDueService _dueService;

    public DueController(IDueService dueService) {
        _dueService = dueService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetDuesAsync(
        [FromQuery] GetDuesRequest req
    ) {
        var dues = await _dueService.GetDues(req);

        return Ok(new ApiResponse<IEnumerable<GetDuesResponse>> {
            Data = dues,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateDuesAsync(
        [FromBody] IEnumerable<CreateDueRequest> req
    ) {
        await _dueService.CreateDues(req);

        return Ok();
    }

    [HttpPut("{dueId}")]
    public async Task<IActionResult> UpdateDueAsync(
        [FromRoute] int dueId,
        [FromBody] UpdateDueRequest req
    ) {
        await _dueService.UpdateDue(dueId, req);

        return Ok();
    }

    [HttpDelete("{dueId}")]
    public async Task<IActionResult> DeleteDueAsync(
        [FromRoute] int dueId
    ) {
        await _dueService.DeleteDue(dueId);

        return Ok();
    }
}