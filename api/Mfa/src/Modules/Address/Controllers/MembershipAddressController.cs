using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Mfa.Modules.Address;

[ApiController]
[Route("api/memberships/{membershipId}/address")]
[Authorize]

public class MembershipAddressController: ControllerBase {
    private readonly IAddressService _addressService;

    public MembershipAddressController(IAddressService addressService) {
        _addressService = addressService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAddressAsync(
        [FromRoute] int membershipId,
        [FromBody] CreateAddressRequest body
    ) {
        await _addressService.CreateAddress(membershipId, body);

        return Ok();
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAddressAsync(
        [FromRoute] int membershipId,
        [FromBody] UpdateAddressRequest body
    ) {
        await _addressService.UpdateAddress(membershipId, body);

        return Ok();
    }

    [HttpDelete("")]
    public async Task<IActionResult> DeleteAddressAsync(
        [FromRoute] int membershipId
    ) {
        await _addressService.DeleteAddress(membershipId);

        return Ok();
    }
}