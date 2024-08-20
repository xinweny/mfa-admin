using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Common.Contracts;

namespace Mfa.Modules.Exchange;

[ApiController]
[Route("api/members/{id}/exchanges")]
[Authorize]

public class MemberExchangeController: ControllerBase {
    private readonly IExchangeService _exchangeService;

    public MemberExchangeController(IExchangeService exchangeService) {
        _exchangeService = exchangeService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMemberExchangesAsync([FromRoute] int id) {
        var exchanges = await _exchangeService.GetMemberExchanges(id);

        return Ok(new ApiResponse<IEnumerable<GetMemberExchangesResponse>> {
            Data = exchanges,
        });
    }
}