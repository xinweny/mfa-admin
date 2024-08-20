using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Common.Contracts;

namespace Mfa.Modules.BoardMember;

[ApiController]
[Route("api/members/{id}/board")]
[Authorize]

public class MemberBoardMemberController: ControllerBase {
    private readonly IBoardMemberService _boardMemberService;

    public MemberBoardMemberController(IBoardMemberService boardMemberService) {
        _boardMemberService = boardMemberService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMemberBoardMembersAsync([FromRoute] int id) {
        var boardMembers = await _boardMemberService.GetMemberBoardMembers(id);

        return Ok(new ApiResponse<IEnumerable<GetMemberBoardMembersResponse>> {
            Data = boardMembers,
        });
    }
}