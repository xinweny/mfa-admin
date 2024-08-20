using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Common.Contracts;

namespace Mfa.Modules.Membership;

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
    public async Task<IActionResult> GetMembershipByIdAsync([FromRoute] int membershipId) {
        var membership = await _membershipService.GetMembershipById(membershipId);

        return Ok(new ApiResponse<GetMembershipResponse> {
            Data = membership,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateMembershipAsync([FromBody] CreateMembershipRequest body) {
        await _membershipService.CreateMembership(body);

        return Ok();
    }

    [HttpPut("{membershipId}")]
    public async Task<IActionResult> UpdateMembershipAsync([FromRoute] int membershipId, [FromBody] UpdateMembershipRequest body) {
        await _membershipService.UpdateMembership(membershipId, body);

        return Ok();
    }

    [HttpDelete("{membershipId}")]
    public async Task<IActionResult> DeleteMembeshipAsync([FromRoute] int membershipId) {
        await _membershipService.DeleteMembership(membershipId);

        return Ok();
    }
}