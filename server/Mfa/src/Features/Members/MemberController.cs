using Microsoft.AspNetCore.Mvc;

using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

[ApiController]
[Route("api/members")]

public class MemberController: ControllerBase {
    private readonly IMemberServices _MemberServices;

    public MemberController(IMemberServices MemberServices) {
        _MemberServices = MemberServices;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMembersAsync([FromQuery] string? query) {
        try {
            IEnumerable<GetMembersResponseDto> members = await _MemberServices.GetMembers(new GetMembersRequestDto {
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
            GetMemberResponseDto member = await _MemberServices.GetMemberById(id);

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
            await _MemberServices.CreateMember(body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateMemberAsync([FromRoute] int id, [FromBody] UpdateMemberRequestDto body) {
        try {
            await _MemberServices.UpdateMember(id, body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteMemberAsync([FromRoute] int id) {
        try {
            await _MemberServices.DeleteMember(id);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }
}