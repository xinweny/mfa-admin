using Microsoft.AspNetCore.Mvc;

using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

[ApiController]
[Route("api/members")]

public class MemberController: ControllerBase {
    private readonly IMemberServices _memberServices;

    public MemberController(IMemberServices memberServices) {
        _memberServices = memberServices;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMembersAsync([FromQuery] string? query) {
        try {
            IEnumerable<GetMembersResponseDto> members = await _memberServices.GetMembers(new GetMembersRequestDto {
                Query = query,
            });

            return Ok(new ResponseDto<IEnumerable<GetMembersResponseDto>> {
                Data = members,
            });
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMemberByIdAsync([FromRoute] int id) {
        try {
            GetMemberResponseDto member = await _memberServices.GetMemberById(id);

            return Ok(new ResponseDto<GetMemberResponseDto> {
                Data = member,
            });
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateMemberAsync([FromBody] CreateMemberRequestDto body) {
        try {
            await _memberServices.CreateMember(body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateMemberAsync([FromRoute] int id, [FromBody] UpdateMemberRequestDto body) {
        try {
            await _memberServices.UpdateMember(id, body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteMemberAsync([FromRoute] int id) {
        try {
            await _memberServices.DeleteMember(id);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }
}