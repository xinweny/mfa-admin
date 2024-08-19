using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Dtos;
using Mfa.Interfaces;

namespace Mfa.Controllers;

[ApiController]
[Route("api/address")]
[Authorize]

public class AddressController: ControllerBase {
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService) {
        _addressService = addressService;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetAddressesAsync() {
        var addresses = await _addressService.GetAddresses();

        return Ok(new ApiResponse<IEnumerable<AddressDto>> {
            Data = addresses,
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressAsync([FromRoute] int id) {
        var address = await _addressService.GetAddress(id);

        return Ok(new ApiResponse<AddressDto> {
            Data = address,
        });
    }
}