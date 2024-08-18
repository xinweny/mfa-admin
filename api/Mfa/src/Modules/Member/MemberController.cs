using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

[ApiController]
[Route("api/members")]
[Authorize]

public class MemberController: ControllerBase {
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService) {
        _memberService = memberService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMembersAsync([FromQuery] string? query) {
        try {
            IEnumerable<GetMembersResponse> members = await _memberService.GetMembers(new GetMembersRequest {
                Query = query,
            });

            return Ok(new ResponseDto<IEnumerable<GetMembersResponse>> {
                Data = members,
            });
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMemberByIdAsync([FromRoute] int id) {
        try {
            GetMemberResponse member = await _memberService.GetMemberById(id);

            return Ok(new ResponseDto<GetMemberResponse> {
                Data = member,
            });
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateMemberAsync([FromBody] CreateMemberRequest body) {
        try {
            await _memberService.CreateMember(body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMemberAsync([FromRoute] int id, [FromBody] UpdateMemberRequest body) {
        try {
            await _memberService.UpdateMember(id, body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMemberAsync([FromRoute] int id) {
        try {
            await _memberService.DeleteMember(id);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }
}