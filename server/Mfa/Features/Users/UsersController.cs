using Microsoft.AspNetCore.Mvc;

using Mfa.Database;
using Microsoft.EntityFrameworkCore;

namespace Mfa.Features.Users;

[ApiController]
[Route("api/[controller]")]

public class UsersController: ControllerBase {
    private readonly MfaContext _context;

    public UsersController(MfaContext context) {
        _context = context;
    }

    [Route("/")]
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers() {
        try {
            return Ok(await _context.Users.ToListAsync());
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }
}