using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Core.Contracts;

namespace MfaApi.Modules.BoardMember;

[ApiController]
[Route("api/board")]
[Authorize]

public class BoardMemberController: ControllerBase {
    private readonly IBoardMemberService _boardMemberService;

    public BoardMemberController(IBoardMemberService boardMemberService) {
        _boardMemberService = boardMemberService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetBoardMembersAsync(
        [FromQuery] GetBoardMembersRequest req
    ) {
        var boardMembers = await _boardMemberService.GetBoardMembers(req);

        return Ok(new ApiResponse<IEnumerable<GetBoardMembersResponse>> {
            Data = boardMembers,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateBoardMemberAsync(
        [FromBody] CreateBoardMemberRequest req
    ) {
        await _boardMemberService.CreateBoardMember(req);

        return Ok();
    }

    [HttpPut("{boardMemberId}")]
    public async Task<IActionResult> UpdateBoardMemberAsync(
        [FromRoute] Guid boardMemberId,
        [FromBody] UpdateBoardMemberRequest req
    ) {
        await _boardMemberService.UpdateBoardMember(boardMemberId, req);

        return Ok();
    }

    [HttpDelete("{boardMemberId}")]
    public async Task<IActionResult> DeleteBoardMemberAsync(
        [FromRoute] Guid boardMemberId
    ) {
        await _boardMemberService.DeleteBoardMember(boardMemberId);

        return Ok();
    }
}