using Microsoft.AspNetCore.Mvc;

using MfaApi.Core.Contracts;

namespace MfaApi.Modules.Due;

[ApiController]
[Route("api/memberships/{membershipId}/dues")]

public class MembershipDueController: ControllerBase {
    private readonly IDueService _dueService;

    public MembershipDueController(IDueService dueService) {
        _dueService = dueService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetDuesAsync(
        [FromRoute] Guid membershipId
    ) {
        var dues = await _dueService.GetMembershipDues(membershipId);

        return Ok(new ApiResponse<IEnumerable<GetMembershipDuesResponse>> {
            Data = dues,
        });
    }
}