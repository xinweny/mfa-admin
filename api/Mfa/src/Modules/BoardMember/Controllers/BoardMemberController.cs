using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Common.Contracts;

namespace Mfa.Modules.BoardMember;

[ApiController]
[Route("api/board")]
[Authorize]

public class BoardMemberController: ControllerBase {
    private readonly IBoardMemberService _boardMemberService;

    public BoardMemberController(IBoardMemberService boardMemberService) {
        _boardMemberService = boardMemberService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetBoardMembersAsync([FromQuery] GetBoardMembersRequest req) {
        var boardMembers = await _boardMemberService.GetBoardMembers(req);

        return Ok(new ApiResponse<IEnumerable<GetBoardMembersResponse>> {
            Data = boardMembers,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateBoardMemberAsync([FromBody] CreateBoardMemberRequest req) {
        await _boardMemberService.CreateBoardMember(req);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBoardMemberAsync([FromRoute] int id, [FromBody] UpdateBoardMemberRequest req) {
        await _boardMemberService.UpdateBoardMember(id, req);

        return Ok();
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> DeleteBoardMemberAsync([FromRoute] int id) {
        await _boardMemberService.DeleteBoardMember(id);

        return Ok();
    }
}