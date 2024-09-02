using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Core.Contracts;

namespace MfaApi.Modules.Address;

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

    [HttpGet("{addressId}")]
    public async Task<IActionResult> GetAddressAsync(
        [FromRoute] Guid addressId
    ) {
        var address = await _addressService.GetAddress(addressId);

        return Ok(new ApiResponse<AddressDto> {
            Data = address,
        });
    }
}