using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Mfa.Modules.Address;

[ApiController]
[Route("api/memberships/{membershipId}/address")]
[Authorize]

public class MembershipAddressController: ControllerBase {
    private readonly IMembershipAddressService _membershipAddressService;

    public MembershipAddressController(IMembershipAddressService membershipAddressService) {
        _membershipAddressService = membershipAddressService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAddressAsync([FromRoute] int membershipId, [FromBody] CreateAddressRequest body) {
        await _membershipAddressService.CreateAddress(membershipId, body);

        return Ok();
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAddressAsync([FromRoute] int membershipId, [FromBody] UpdateAddressRequest body) {
        await _membershipAddressService.UpdateAddress(membershipId, body);

        return Ok();
    }

    [HttpDelete("")]
    public async Task<IActionResult> DeleteAddressAsync([FromRoute] int membershipId) {
        await _membershipAddressService.DeleteAddress(membershipId);

        return Ok();
    }
}