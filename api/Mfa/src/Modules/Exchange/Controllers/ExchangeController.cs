using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Common.Contracts;

namespace Mfa.Modules.Exchange;

[ApiController]
[Route("api/exchanges")]
[Authorize]

public class ExchangeController: ControllerBase {
    private readonly IExchangeService _exchangeService;

    public ExchangeController(IExchangeService exchangeService) {
        _exchangeService = exchangeService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetExchangesAsync([FromQuery] GetExchangesRequest req) {
        var exchanges = await _exchangeService.GetExchanges(req);

        return Ok(new ApiResponse<IEnumerable<GetExchangesResponse>> {
            Data = exchanges,
        });
    }
}