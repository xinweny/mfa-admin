using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Common.Contracts;

namespace Mfa.Modules.Member;

[ApiController]
[Route("api/members")]
[Authorize]

public class MemberController: ControllerBase {
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService) {
        _memberService = memberService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMembersAsync([FromQuery] GetMembersRequest req) {
        var members = await _memberService.GetMembers(req);
        
        return Ok(new ApiResponse<IEnumerable<GetMembersResponse>> {
            Data = members,
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMemberByIdAsync([FromRoute] int id) {
        var member = await _memberService.GetMemberById(id);

        return Ok(new ApiResponse<GetMemberResponse> {
            Data = member,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateMemberAsync([FromBody] CreateMemberRequest body) {
        await _memberService.CreateMember(body);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMemberAsync([FromRoute] int id, [FromBody] UpdateMemberRequest body) {
        await _memberService.UpdateMember(id, body);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMemberAsync([FromRoute] int id) {
        await _memberService.DeleteMember(id);

        return Ok();
    }
}