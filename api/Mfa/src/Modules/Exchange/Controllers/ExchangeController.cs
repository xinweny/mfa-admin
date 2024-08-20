using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Mfa.Common.Contracts;

namespace Mfa.Modules.Exchange;

[ApiController]
[Route("api/exchanges")]
[Authorize]

public class ExchangeController: ControllerBase {
    private readonly IMemberService _memberService;

    public ExchangeController(IMemberService memberService) {
        _memberService = memberService;
    }
}