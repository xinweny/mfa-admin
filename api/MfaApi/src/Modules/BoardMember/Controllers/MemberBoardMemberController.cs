using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Core.Contracts;

namespace MfaApi.Modules.BoardMember;

[Authorize]
[ApiController]
[Route("api/members/{memberId}/board")]

public class MemberBoardMemberController: ControllerBase {
    private readonly IBoardMemberService _boardMemberService;

    public MemberBoardMemberController(
        IBoardMemberService boardMemberService
    ) {
        _boardMemberService = boardMemberService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMemberBoardMembersAsync(
        [FromRoute] Guid memberId
    ) {
        var boardMembers = await _boardMemberService.GetMemberBoardMembers(memberId);

        return Ok(new ApiResponse<IEnumerable<GetMemberBoardMembersResponse>> {
            Data = boardMembers,
        });
    }
}