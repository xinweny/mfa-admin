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
    public async Task<IActionResult> GetMembershipsAsync([FromQuery] string? query) {
        try {
            throw new NotImplementedException();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMembershipByIdAsync([FromRoute] int id) {
        try {
            var membership = await _membershipService.GetMembershipById(id);

            return Ok(new ResponseDto<GetMembershipResponse> {
                Data = membership,
            });
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateMembershipAsync([FromBody] CreateMembershipRequest body) {
        try {
            await _membershipService.CreateMembership(body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMembershipAsync([FromRoute] int id, [FromBody] UpdateMembershipRequest body) {
        try {
            await _membershipService.UpdateMembership(id, body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMembeshipAsync([FromRoute] int id) {
        try {
            await _membershipService.DeleteMembership(id);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }
}