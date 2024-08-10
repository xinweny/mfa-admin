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

            return Ok(new ResponseDto<GetMembershipResponseDto> {
                Data = membership,
            });
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateMembershipAsync([FromBody] CreateMemberRequestDto body) {
        try {
            throw new NotImplementedException();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateMembershipAsync([FromRoute] int id, [FromBody] UpdateMemberRequestDto body) {
        try {
            throw new NotImplementedException();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteMembeshipAsync([FromRoute] int id) {
        try {
            throw new NotImplementedException();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }
}