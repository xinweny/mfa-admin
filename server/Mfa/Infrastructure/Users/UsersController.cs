using Microsoft.AspNetCore.Mvc;

namespace Mfa.Infrastructure.Users;

[ApiController]
[Route("api/users")]

public class UsersController: ControllerBase {
    private readonly UserServices _userServices;

    public UsersController(UserServices userServices) {
        _userServices = userServices;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetUsersAsync([FromQuery] string? query) {
        try {
            return Ok(await _userServices.GetQueriedUsersAsync(query));
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id) {
        try {
            User? user = await _userServices.GetUserByIdAsync(id);

            return user == null ? NotFound() : Ok(user);
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto body) {
        try {
            await _userServices.CreateUserAsync(body);

            return Ok();
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("{id}"), ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUserAsync([FromRoute] int id, [FromBody] UpdateUserDto body) {
        try {
            await _userServices.UpdateUserAsync(id, body);

            return Ok();
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }
}