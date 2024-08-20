using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Mfa.Modules.Due;

[ApiController]
[Route("api/dues")]
[Authorize]

public class DueController: ControllerBase {
    private readonly IDueService _dueService;

    public DueController(IDueService dueService) {
        _dueService = dueService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateDuesAsync([FromBody] IEnumerable<CreateDueRequest> req) {
        await _dueService.CreateDues(req);

        return Ok();
    }
}