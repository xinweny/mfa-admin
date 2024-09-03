using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Core.Contracts;
using MfaApi.Core.Pagination;

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
        var pagination = new PaginationMetadata();

        var members = await _memberService.GetMembers(req, pagination);
        
        return Ok(new ApiResponse<IEnumerable<GetMembersResponse>> {
            Metadata = new ApiMetadata {
                Pagination = pagination,
            },
            Data = members,
        });
    }

    [HttpGet("{memberId}")]
    public async Task<IActionResult> GetMemberByIdAsync(
        [FromRoute] Guid memberId
    ) {
        var member = await _memberService.GetMemberById(memberId);

        return Ok(new ApiResponse<GetMemberResponse> {
            Data = member,
        });
    }

    [HttpPut("{memberId}")]
    public async Task<IActionResult> UpdateMemberAsync(
        [FromRoute] Guid memberId,
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
        [FromRoute] Guid memberId
    ) {
        await _memberService.DeleteMember(memberId);

        return Ok();
    }
}