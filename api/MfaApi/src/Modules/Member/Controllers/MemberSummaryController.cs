using Microsoft.AspNetCore.Mvc;

using MfaApi.Core.Contracts;

namespace MfaApi.Modules.Member;

[ApiController]
[Route("api/members/summary")]

public class MemberSummaryController: ControllerBase {
    private readonly IMemberSummaryService _memberSummaryService;

    public MemberSummaryController(IMemberSummaryService memberSummaryService) {
        _memberSummaryService = memberSummaryService;
    }

    [HttpGet("counts")]
    public async Task<IActionResult> GetMembersCountsAsync() {
        var counts = await _memberSummaryService.GetMembersCounts();
        
        return Ok(new ApiResponse<GetMembersCountsResponse> {
            Data = counts,
        });
    }

    [HttpGet("joined")]
    public async Task<IActionResult> GetMembersByDateAsync([FromQuery] GetMembersByDateRequest req) {
        var members = await _memberSummaryService.GetMembersByDate(req);

        return Ok(new ApiResponse<List<GetMembersByDateResponse>> {
            Data = members,
        });
    }
}