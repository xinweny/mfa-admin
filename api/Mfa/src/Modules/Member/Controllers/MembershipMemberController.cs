using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Mfa.Modules.Member;

[ApiController]
[Route("api/memberships/{membershipId}/members")]
[Authorize]

public class MembershipMemberController: ControllerBase {
    private readonly IMembershipMemberService _membershipMemberService;

    public MembershipMemberController(IMembershipMemberService membershipMemberService) {
        _membershipMemberService = membershipMemberService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateMemberAsync(
        [FromRoute] int membershipId,
        [FromBody] CreateMemberRequest body
    ) {
        await _membershipMemberService.CreateMember(body, membershipId);

        return Ok();
    }

    [HttpDelete("{memberId}")]
    public async Task<IActionResult> DeleteMemberAsync(
        [FromRoute] int membershipId,
        [FromRoute] int memberId
    ) {
        await _membershipMemberService.DeleteMember(memberId, membershipId);

        return Ok();
    }
}