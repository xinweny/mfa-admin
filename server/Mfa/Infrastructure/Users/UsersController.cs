using Microsoft.AspNetCore.Mvc;

using Mfa.Database;

namespace Mfa.Infrastructure.Users;

[ApiController]
[Route("api/[controller]")]

public class UsersController: ControllerBase {
    private readonly UsersService _service;

    public UsersController(MfaDbContext context) {
        _service = new UsersService(context);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetUsersAsync([FromQuery] string? query) {
        try {
            return Ok(await _service.GetQueriedUsersAsync(query));
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id) {
        try {
            return Ok(await _service.GetUserByIdAsync(id));
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }
}