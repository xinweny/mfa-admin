using Microsoft.AspNetCore.Mvc;

using Mfa.Database;
using Microsoft.EntityFrameworkCore;

namespace Mfa.Features.Users;

[ApiController]
[Route("api/[controller]")]

public class UsersController: ControllerBase {
    private readonly MfaDbContext _context;

    public UsersController(MfaDbContext context) {
        _context = context;
    }

    [HttpGet("")]
    public async Task<ActionResult<List<User>>> GetAllAsync() {
        try {
            return Ok(await _context.Users.ToListAsync());
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }
}