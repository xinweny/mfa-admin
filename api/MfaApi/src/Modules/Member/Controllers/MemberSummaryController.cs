using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Core.Contracts;

namespace MfaApi.Modules.Member;

[ApiController]
[Route("api/members/summary")]
[Authorize]

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
}