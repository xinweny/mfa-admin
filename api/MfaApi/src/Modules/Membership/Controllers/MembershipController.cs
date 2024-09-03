using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Core.Contracts;
using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Membership;

[ApiController]
[Route("api/memberships")]
[Authorize]

public class MembershipController: ControllerBase {
    private readonly IMembershipService _membershipService;
    private readonly IPaginationService _paginationService;

    public MembershipController(
        IMembershipService membershipService,
        IPaginationService paginationService
    ) {
        _membershipService = membershipService;
        _paginationService = paginationService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMembershipsAsync([FromQuery] GetMembershipsRequest req) {
        var pagination = await _paginationService.GetOffsetPagination<MembershipModel>(req);

        var memberships = await _membershipService.GetMemberships(req);

        pagination?.SetCurrentCount(memberships.Count());

        return Ok(new ApiResponse<IEnumerable<GetMembershipsResponse>> {
            Metadata = new ApiMetadata {
                Pagination = pagination,
            },
            Data = memberships,
        });
    }

    [HttpGet("{membershipId}")]
    public async Task<IActionResult> GetMembershipByIdAsync(
        [FromRoute] Guid membershipId
    ) {
        var membership = await _membershipService.GetMembershipById(membershipId);

        return Ok(new ApiResponse<GetMembershipResponse> {
            Data = membership,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateMembershipAsync(
        [FromBody] CreateMembershipRequest body
    ) {
        await _membershipService.CreateMembership(body);

        return Ok();
    }

    [HttpPut("{membershipId}")]
    public async Task<IActionResult> UpdateMembershipAsync(
        [FromRoute] Guid membershipId,
        [FromBody] UpdateMembershipRequest body
    ) {
        await _membershipService.UpdateMembership(membershipId, body);

        return Ok();
    }

    [HttpDelete("{membershipId}")]
    public async Task<IActionResult> DeleteMembeshipAsync(
        [FromRoute] Guid membershipId
    ) {
        await _membershipService.DeleteMembership(membershipId);

        return Ok();
    }
}