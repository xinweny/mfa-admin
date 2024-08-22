using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Common.Contracts;

namespace MfaApi.Modules.Due;

[ApiController]
[Route("api/memberships/{membershipId}/dues")]
[Authorize]

public class MembershipDueController: ControllerBase {
    private readonly IDueService _dueService;

    public MembershipDueController(IDueService dueService) {
        _dueService = dueService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetDuesAsync(
        [FromRoute] int membershipId
    ) {
        var dues = await _dueService.GetMembershipDues(membershipId);

        return Ok(new ApiResponse<IEnumerable<GetMembershipDuesResponse>> {
            Data = dues,
        });
    }
}