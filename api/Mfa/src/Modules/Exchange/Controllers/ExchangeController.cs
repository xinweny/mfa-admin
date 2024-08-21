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
    public async Task<IActionResult> GetExchangesAsync(
        [FromQuery] GetExchangesRequest req
    ) {
        var exchanges = await _exchangeService.GetExchanges(req);

        return Ok(new ApiResponse<IEnumerable<GetExchangesResponse>> {
            Data = exchanges,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateExchangesAsync(
        [FromBody] IEnumerable<CreateExchangeRequest> req
    ) {
        await _exchangeService.CreateExchanges(req);

        return Ok();
    }

    [HttpPut("{exchangeId}")]
    public async Task<IActionResult> UpdateExchangeAsync(
        [FromRoute] int exchangeId,
        [FromBody] UpdateExchangeRequest req
    ) {
        await _exchangeService.UpdateExchange(exchangeId, req);

        return Ok();
    }

    [HttpPost("{exchangeId}")]
    public async Task<IActionResult> DeleteExchangeAsync(
        [FromRoute] int exchangeId
    ) {
        await _exchangeService.DeleteExchange(exchangeId);

        return Ok();
    }
}