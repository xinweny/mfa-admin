using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Core.Contracts;

namespace MfaApi.Modules.Address;

[Authorize]
[ApiController]
[Route("api/memberships/{membershipId}/address")]

public class MembershipAddressController: ControllerBase {
    private readonly IAddressService _addressService;

    public MembershipAddressController(IAddressService addressService) {
        _addressService = addressService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAddressAsync(
        [FromRoute] Guid membershipId,
        [FromBody] CreateAddressRequest body
    ) {
        await _addressService.CreateAddress(membershipId, body);

        return Ok(new ApiResponse<object> {
            Data = null,
        });
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAddressAsync(
        [FromRoute] Guid membershipId,
        [FromBody] UpdateAddressRequest body
    ) {
        await _addressService.UpdateAddress(membershipId, body);

        return Ok(new ApiResponse<object> {
            Data = null,
        });
    }

    [HttpDelete("")]
    public async Task<IActionResult> DeleteAddressAsync(
        [FromRoute] Guid membershipId
    ) {
        await _addressService.DeleteAddress(membershipId);

        return Ok(new ApiResponse<object> {
            Data = null,
        });
    }
}