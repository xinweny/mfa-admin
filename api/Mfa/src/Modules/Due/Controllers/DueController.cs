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
    public async Task<IActionResult> GetDuesAsync([FromQuery] GetDuesRequest req) {
        var dues = await _dueService.GetDues(null, req);

        return Ok(new ApiResponse<IEnumerable<GetDuesResponse>> {
            Data = dues,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateDuesAsync([FromBody] IEnumerable<CreateDueRequest> req) {
        await _dueService.CreateDues(req);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDueAsync([FromRoute] int id, [FromBody] UpdateDueRequest req) {
        await _dueService.UpdateDue(id, req);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDueAsync([FromRoute] int id) {
        await _dueService.DeleteDue(id);

        return Ok();
    }
}