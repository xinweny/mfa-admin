using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MfaApi.Common.Contracts;

namespace MfaApi.Modules.Exchange;

[ApiController]
[Route("api/members/{memberId}/exchanges")]
[Authorize]

public class MemberExchangeController: ControllerBase {
    private readonly IExchangeService _exchangeService;

    public MemberExchangeController(IExchangeService exchangeService) {
        _exchangeService = exchangeService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMemberExchangesAsync(
        [FromRoute] Guid memberId
    ) {
        var exchanges = await _exchangeService.GetMemberExchanges(memberId);

        return Ok(new ApiResponse<IEnumerable<GetMemberExchangesResponse>> {
            Data = exchanges,
        });
    }
}