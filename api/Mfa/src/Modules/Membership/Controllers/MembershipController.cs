using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMembershipByIdAsync([FromRoute] int id) {
        var membership = await _membershipService.GetMembershipById(id);

        return Ok(new ApiResponse<GetMembershipResponse> {
            Data = membership,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateMembershipAsync([FromBody] CreateMembershipRequest body) {
        await _membershipService.CreateMembership(body);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMembershipAsync([FromRoute] int id, [FromBody] UpdateMembershipRequest body) {
        await _membershipService.UpdateMembership(id, body);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMembeshipAsync([FromRoute] int id) {
        await _membershipService.DeleteMembership(id);

        return Ok();
    }
}