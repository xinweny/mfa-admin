using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Common.Contracts;

namespace MfaApi.Modules.Member;

[ApiController]
[Route("api/members")]
[Authorize]

public class MemberController: ControllerBase {
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService) {
        _memberService = memberService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMembersAsync(
        [FromQuery] GetMembersRequest req
    ) {
        var members = await _memberService.GetMembers(req);
        
        return Ok(new ApiResponse<IEnumerable<GetMembersResponse>> {
            Data = members,
        });
    }

    [HttpGet("{memberId}")]
    public async Task<IActionResult> GetMemberByIdAsync(
        [FromRoute] int memberId
    ) {
        var member = await _memberService.GetMemberById(memberId);

        return Ok(new ApiResponse<GetMemberResponse> {
            Data = member,
        });
    }

    [HttpPut("{memberId}")]
    public async Task<IActionResult> UpdateMemberAsync(
        [FromRoute] int memberId,
        [FromBody] UpdateMemberRequest body
    ) {
        await _memberService.UpdateMember(memberId, body);

        return Ok();
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateMemberAsync(
        [FromBody] CreateMemberRequest body
    ) {
        await _memberService.CreateMember(body);

        return Ok();
    }

    [HttpDelete("{memberId}")]
    public async Task<IActionResult> DeleteMemberAsync(
        [FromRoute] int memberId
    ) {
        await _memberService.DeleteMember(memberId);

        return Ok();
    }
}