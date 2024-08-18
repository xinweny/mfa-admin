using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

[ApiController]
[Route("api/memberships/{id}/address")]
[Authorize]

public class AddressController: ControllerBase {
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService) {
        _addressService = addressService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateAddressAsync([FromRoute] int membershipId, [FromBody] CreateAddressRequest body) {
        try {
            await _addressService.CreateAddress(membershipId, body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAddressAsync([FromRoute] int membershipId, [FromBody] UpdateAddressRequest body) {
        try {
            await _addressService.UpdateAddress(membershipId, body);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("")]
    public async Task<IActionResult> DeleteAddressAsync([FromRoute] int membershipId) {
        try {
            await _addressService.DeleteAddress(membershipId);

            return Ok();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }
}