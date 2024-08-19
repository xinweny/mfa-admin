using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

[ApiController]
[Route("api/memberships/{id}/address")]
[Authorize]

public class MembershipAddressController: ControllerBase {
    private readonly IMembershipAddressService _membershipAddressService;

    public MembershipAddressController(IMembershipAddressService membershipAddressService) {
        _membershipAddressService = membershipAddressService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAddressAsync([FromRoute] int id, [FromBody] CreateAddressRequest body) {
        await _membershipAddressService.CreateAddress(id, body);

        return Ok();
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAddressAsync([FromRoute] int id, [FromBody] UpdateAddressRequest body) {
        await _membershipAddressService.UpdateAddress(id, body);

        return Ok();
    }

    [HttpDelete("")]
    public async Task<IActionResult> DeleteAddressAsync([FromRoute] int id) {
        await _membershipAddressService.DeleteAddress(id);

        return Ok();
    }
}