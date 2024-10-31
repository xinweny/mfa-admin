using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Core.Contracts;

namespace MfaApi.Modules.Membership;

[Authorize]
[ApiController]
[Route("api/memberships/summary")]

public class MembershipSummaryController: ControllerBase {
    private readonly IMembershipSummaryService _membershipSummaryService;

    public MembershipSummaryController(IMembershipSummaryService membershipSummaryService) {
        _membershipSummaryService = membershipSummaryService;
    }

    [HttpGet("membership-types")]
    public async Task<IActionResult> GetMembershipTypeCountsAsync() {
        var counts = await _membershipSummaryService.GetMembershipTypeCounts();

        return Ok(new ApiResponse<GetMembershipTypeCountsResponse> {
            Data = counts,
        });
    }

    [HttpGet("dues")]
    public async Task<IActionResult> GetMembershipDueTotalsAsync(
        [FromRoute] GetMembershipDueTotalsRequest req
    ) {
        var dueTotals = await _membershipSummaryService.GetMembershipDueTotals(req);

        return Ok(new ApiResponse<GetMembershipDueTotalsResponse> {
            Data = dueTotals,
        });
    }
}