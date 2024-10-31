using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Core.Contracts;
using MfaApi.Core.Pagination;

namespace MfaApi.Modules.Exchange;

[Authorize]
[ApiController]
[Route("api/exchanges")]

public class ExchangeController: ControllerBase {
    private readonly IExchangeService _exchangeService;

    public ExchangeController(IExchangeService exchangeService) {
        _exchangeService = exchangeService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetExchangesAsync(
        [FromQuery] GetExchangesRequest req
    ) {
        var pagination = new PaginationMetadata();

        var exchanges = await _exchangeService.GetExchanges(req, pagination);

        return Ok(new ApiResponse<IEnumerable<GetExchangesResponse>> {
            Metadata = new ApiMetadata {
                Pagination = pagination,
            },
            Data = exchanges,
        });
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateExchangesAsync(
        [FromBody] CreateExchangesRequest req
    ) {
        await _exchangeService.CreateExchanges(req);

        return Ok();
    }

    [HttpPut("{exchangeId}")]
    public async Task<IActionResult> UpdateExchangeAsync(
        [FromRoute] Guid exchangeId,
        [FromBody] UpdateExchangeRequest req
    ) {
        await _exchangeService.UpdateExchange(exchangeId, req);

        return Ok();
    }

    [HttpPost("{exchangeId}")]
    public async Task<IActionResult> DeleteExchangeAsync(
        [FromRoute] Guid exchangeId
    ) {
        await _exchangeService.DeleteExchange(exchangeId);

        return Ok();
    }
}