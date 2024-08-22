using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Common.Contracts;

namespace MfaApi.Modules.Membership;

[ApiController]
[Route("api/memberships")]
[Authorize]

public class MembershipController: ControllerBase {
    private readonly IMembershipService _membershipService;

    public MembershipController(IMembershipService membershipService) {
        _membershipService = membershipService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMembershipsAsync() {
        var memberships = await _membershipService.GetMemberships();

        return Ok(new ApiResponse<IEnumerable<GetMembershipsResponse>> {
            Data = memberships,
        });
    }

    [HttpGet("{membershipId}")]
    public async Task<IActionResult> GetMembershipByIdAsync(
        [FromRoute] Guid membershipId
    ) {
        var membership = await _membershipService.GetMembershipById(membershipId);

        return Ok(new ApiResponse<GetMembershipResponse> {
            Data = membership,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateMembershipAsync(
        [FromBody] CreateMembershipRequest body
    ) {
        await _membershipService.CreateMembership(body);

        return Ok();
    }

    [HttpPut("{membershipId}")]
    public async Task<IActionResult> UpdateMembershipAsync(
        [FromRoute] Guid membershipId,
        [FromBody] UpdateMembershipRequest body
    ) {
        await _membershipService.UpdateMembership(membershipId, body);

        return Ok();
    }

    [HttpDelete("{membershipId}")]
    public async Task<IActionResult> DeleteMembeshipAsync(
        [FromRoute] Guid membershipId
    ) {
        await _membershipService.DeleteMembership(membershipId);

        return Ok();
    }
}