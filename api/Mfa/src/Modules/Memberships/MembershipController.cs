using Microsoft.AspNetCore.Mvc;

using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

[ApiController]
[Route("api/memberships")]

public class MembershipController: ControllerBase {
    private readonly IMembershipServices _membershipServices;

    public MembershipController(IMembershipServices membershipServices) {
        _membershipServices = membershipServices;
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
            var membership = await _membershipServices.GetMembershipById(id);

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
            await _membershipServices.CreateMembership(body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateMembershipAsync([FromRoute] int id, [FromBody] UpdateMemberRequest body) {
        try {
            throw new NotImplementedException();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMembeshipAsync([FromRoute] int id) {
        try {
            throw new NotImplementedException();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }
}