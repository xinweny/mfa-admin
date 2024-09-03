using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Core.Contracts;
using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Due;

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
        var pagination = new PaginationMetadata();

        var dues = await _dueService.GetDues(req, pagination);

        return Ok(new ApiResponse<IEnumerable<GetDuesResponse>> {
            Metadata = new ApiMetadata {
                Pagination = pagination,
            },
            Data = dues,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateDuesAsync(
        [FromBody] CreateDuesRequest req
    ) {
        await _dueService.CreateDues(req);

        return Ok();
    }

    [HttpPut("{dueId}")]
    public async Task<IActionResult> UpdateDueAsync(
        [FromRoute] Guid dueId,
        [FromBody] UpdateDueRequest req
    ) {
        await _dueService.UpdateDue(dueId, req);

        return Ok();
    }

    [HttpDelete("{dueId}")]
    public async Task<IActionResult> DeleteDueAsync(
        [FromRoute] Guid dueId
    ) {
        await _dueService.DeleteDue(dueId);

        return Ok();
    }
}