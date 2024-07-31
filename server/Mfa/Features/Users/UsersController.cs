using Microsoft.AspNetCore.Mvc;

using Mfa.Database;
using System.Diagnostics;

namespace Mfa.Features.Users;

[ApiController]
[Route("api/[controller]")]

public class UsersController: ControllerBase {
    private readonly UsersService _service;

    public UsersController(MfaDbContext context) {
        _service = new UsersService(context);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllUsersAsync() {
        try {
            return Ok(await _service.GetAllAsync());
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id) {
        try {
            return Ok(await _service.GetByIdAsync(id));
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }
}